using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BildungsberichtTemplate
{
    public partial class MainWindow : Window
    {
        public const string PDF_VORLAGE = "Bildungsbericht_Vorname_Nachname_x_Semester.pdf";
        private BildungsberichtModel model = new BildungsberichtModel();
        private readonly BildungsberichtLiteDb bildungsberichtDb = new BildungsberichtLiteDb();
        private readonly BewertungsBeschreibungLiteDb bewertungsBeschreibungDb = new BewertungsBeschreibungLiteDb();

        public MainWindow()
        {
            InitializeComponent();
            base.DataContext = model.BewertungenModels;
            Coach.ItemsSource = (from x in Lernende.GetLernende()
                                 select x.Coach).Distinct();
        }

        private void CreatePDF_OnClick(object sender, RoutedEventArgs e)
        {
            if (this.model.Lernende == null)
            {
                Message.ShowWarning("Kein Lernender ausgewählt!");
                return;
            }

            PDFManipulator pdf = new PDFManipulator("Bildungsbericht_Vorname_Nachname_x_Semester.pdf", string.Format(arg2: (model.Semester != 0) ? "2" : "1", format: "Bildungsbericht_{0}_{1}_{2}_Semester.pdf", arg0: model.Lernende.Vorname, arg1: model.Lernende.Name));
            foreach (BewertungModel item in (List<BewertungModel>)base.DataContext)
            {
                string value = string.Empty;
                switch (item.GetNote())
                {
                    case EnumNote.A:
                        value = "A";
                        break;
                    case EnumNote.B:
                        value = "B";
                        break;
                    case EnumNote.C:
                        value = "C";
                        break;
                    case EnumNote.D:
                        value = "D";
                        break;
                }
                if (model.Semester == Semester.Erstes)
                {
                    pdf.SetValue("1 Semester", "Yes");
                }
                else
                {
                    pdf.SetValue("2 Semester", "Yes");
                }
                if (!string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(item.Bewertung.PdfFieldKey))
                {
                    pdf.SetValue($"{item.Bewertung.PdfFieldKey}_{value}", "Yes");
                }

                if (item.Bewertung != null && !string.IsNullOrEmpty(item.Bewertung.Beschreibung) && !string.IsNullOrEmpty(item.Bewertung.PdfFieldKey))
                {
                    pdf.SetValue($"{item.Bewertung.PdfFieldKey}_Beurteilung", TextEscaping.removeKeywords(item.Bewertung.Beschreibung, this.model.Lernende));
                }
                else if (item.SelectedBeschreibung != null && !string.IsNullOrEmpty(item.SelectedBeschreibung.ToString()) && !string.IsNullOrEmpty(item.Bewertung.PdfFieldKey))
                {
                    pdf.SetValue($"{item.Bewertung.PdfFieldKey}_Beurteilung", TextEscaping.removeKeywords(item.SelectedBeschreibung.ToString(), this.model.Lernende));
                }
            }

            pdf.SetValue("Lernende Person", $"{model.Lernende.Name} {model.Lernende.Vorname}");
            if (model.Lernende.Coach == "Mathias")
            {
                pdf.SetValue("Verantwortlich", "Mathias Rieder");
            }
            else if (model.Lernende.Coach == "Alexandra")
            {
                pdf.SetValue("Verantwortlich", "Alexandra Ferrari");
            }
            else if (model.Lernende.Coach == "Martin")
            {
                pdf.SetValue("Verantwortlich", "Martin Müller");
            }
            else if (model.Lernende.Coach == "Marco")
            {
                pdf.SetValue("Verantwortlich", "Marco Rohr");
            }
            pdf.SetValue("Lehrbetrieb", model.Lernende.Lehrbetrieb);
            pdf.SetValue("Vom_Datum", "06. August 2018");
            pdf.SetValue("Bis_Datum", "31. Oktober 2018");
            pdf.Close();

            Message.ShowSuccess(string.Format("Bildungsbericht von {0} wurde erstellt.", model.Lernende.Vorname));
        }

        private void Coach_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            Lernender.ItemsSource = from x in Lernende.GetLernende()
                                    where x.Coach == comboBox.SelectedItem.ToString()
                                    select x;
        }

        private void Lernender_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Lernende lernende = (Lernende)((ComboBox)sender).SelectedItem;
            if (lernende == null)
            {
                BewertungsListBox.IsEnabled = false;
                return;
            }

            BewertungsListBox.IsEnabled = true;

            model = bildungsberichtDb.GetBildungsberichtByLernender(lernende.Name, lernende.Vorname);
            if (model == null)
            {
                model = new BildungsberichtModel();
                model.Lernende = lernende;
                model.Von = "03.August 2018";
                model.Bis = "31.Oktober 2018";
                model.Semester = Semester.Erstes;
                model.Id = bildungsberichtDb.InsertBildungsbericht(model);
            }

            base.DataContext = model.BewertungenModels;
        }

        private void SaveAsNewTemplate_OnClick(object sender, RoutedEventArgs e)
        {
            BewertungModel bewertungModel = (BewertungModel)((Button)sender).DataContext;

            if (bewertungModel == null || string.IsNullOrWhiteSpace(bewertungModel.Bewertung.Beschreibung)) {

                Message.ShowWarning("Bitte gibt einen gütligen Text ein.");
                return;
            }

            BewertungsBeschreibung bewertungsBeschreibung = new BewertungsBeschreibung();
            bewertungsBeschreibung.SubKategorie = bewertungModel.Bewertung.SubKategorie;
            bewertungsBeschreibung.Kategorie = bewertungModel.Bewertung.Kategorie;
            bewertungsBeschreibung.Note = bewertungModel.GetNote();
            bewertungsBeschreibung.Beschreibung = bewertungModel.Bewertung.Beschreibung;
            bewertungsBeschreibung.Id = bewertungsBeschreibungDb.InsertBewertungsBeschreibung(bewertungsBeschreibung, model.Lernende.Vorname);

            bewertungModel.SelectedBeschreibung = bewertungsBeschreibung;

            RefreshBewertungsBeschreibungen(bewertungModel, (StackPanel)((Button)sender).Parent);
            Message.ShowSuccess("Die neue Vorlage ist gespeichert!");
        }

        private void DeleteTemplate_OnClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            BewertungModel bewertungModel = (BewertungModel)button.DataContext;
            if (bewertungModel.SelectedBeschreibung == null || bewertungModel.SelectedBeschreibung.Id == 0)
            {
                Message.ShowWarning("Du hast keine Vorlage ausgewählt!");
                return;
            }

            bewertungsBeschreibungDb.DeleteBewertungsBeschreibung(bewertungModel.SelectedBeschreibung.Id);
            RefreshBewertungsBeschreibungen(bewertungModel, (StackPanel)button.Parent);
            Message.ShowSuccess("Die Vorlage ist gelöscht!");
        }

        private void UpdateTemplate_OnClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            BewertungModel bewertungModel = (BewertungModel)button.DataContext;
            if (bewertungModel.SelectedBeschreibung == null || bewertungModel.SelectedBeschreibung.Id == 0 ||
                string.IsNullOrWhiteSpace(bewertungModel.Bewertung.Beschreibung))
            {
                Message.ShowWarning("Ungültige Eingabe");
                return;
            }

            var newText = string.Empty;
            foreach (object child in ((StackPanel)button.Parent).Children)
            {
                if (child is TextBox)
                {
                    newText = ((TextBox)child).Text;
                }
            }

            bewertungModel.SelectedBeschreibung.Beschreibung = newText;
            bewertungsBeschreibungDb.UpdateBewertungsBeschreibung(bewertungModel.SelectedBeschreibung, model.Lernende.Vorname);

            RefreshBewertungsBeschreibungen(bewertungModel, (StackPanel)button.Parent);
            Message.ShowSuccess("Die Vorlage ist angepasst!");

        }

        private void RefreshBewertungsBeschreibungen(BewertungModel bewertungModel, StackPanel stackPanel)
        {
            UpdateDropBox(bewertungModel, stackPanel, bewertungModel.GetNote());
        }

        private void Note_OnChecked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            EnumNote note = ConvertToNote(radioButton.Name);
            UpdateDropBox((BewertungModel)radioButton.DataContext, (StackPanel)radioButton.Parent, note);
            UpdateBildungsberichtInDB();
        }

        private void ComboBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var comboBox = ((ComboBox)sender);
            RefreshBewertungsBeschreibungen((BewertungModel)comboBox.DataContext, (StackPanel)comboBox.Parent);
        }

        private void UpdateDropBox(BewertungModel bewertungModel, StackPanel stackPanel, EnumNote note)
        {
            ComboBox comboBox = null;
            foreach (object child in stackPanel.Children)
            {
                if (child is ComboBox)
                {
                    comboBox = (ComboBox)child;
                }
            }
            model.BewertungenBeschreibungenModels = new ObservableCollection<BewertungsBeschreibung>();
            foreach (BewertungsBeschreibung item in bewertungsBeschreibungDb.GetBewertungsBeschreibung(bewertungModel.Bewertung.Kategorie, bewertungModel.Bewertung.SubKategorie, note, model.Lernende))
            {
                model.BewertungenBeschreibungenModels.Add(item);
            }
            if (comboBox != null)
            {
                comboBox.ItemsSource = model.BewertungenBeschreibungenModels;
            }
        }

        private EnumNote ConvertToNote(string note)
        {
            if (note == "A")
            {
                return EnumNote.A;
            }
            if (note == "B")
            {
                return EnumNote.B;
            }
            if (note == "C")
            {
                return EnumNote.C;
            }
            if (note == "D")
            {
                return EnumNote.D;
            }
            throw new InvalidEnumArgumentException(note);
        }

        private void Beschreibung_OnSelected(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            UIElementCollection children2 = ((StackPanel)comboBox.Parent).Children;
            BewertungsBeschreibung bewertungsBeschreibung = null;
            foreach (object item in children2)
            {
                if (item is TextBox)
                {
                    if (comboBox.SelectedItem != null)
                    {
                        bewertungsBeschreibung = (BewertungsBeschreibung)comboBox.SelectedItem;
                    }
                    else if (comboBox.SelectionBoxItem != null)
                    {
                        bewertungsBeschreibung = (BewertungsBeschreibung)comboBox.SelectionBoxItem;
                    }
                    TextBox obj = (TextBox)item;
                    obj.Text = bewertungsBeschreibung.Beschreibung;
                    ((BewertungModel)obj.DataContext).SelectedBeschreibung = bewertungsBeschreibung;
                    ((BewertungModel)obj.DataContext).Bewertung.Beschreibung = bewertungsBeschreibung.Beschreibung;
                }
            }

            UpdateDropBox((BewertungModel)comboBox.DataContext, (StackPanel)comboBox.Parent, bewertungsBeschreibung.Note);
            UpdateBildungsberichtInDB();
        }

        private void Beschreibung_OnLostFokus(object sender, RoutedEventArgs e)
        {
            UpdateBildungsberichtInDB();
        }

        private void UpdateBildungsberichtInDB() {
            model.BewertungenModels = (List<BewertungModel>)base.DataContext;
            bildungsberichtDb.UpdateBildungsbericht(model);
        }
    }
}