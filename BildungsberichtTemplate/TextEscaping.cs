using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BildungsberichtTemplate
{
    public static class TextEscaping
    {
        private static List<GenderTranslate> genderTextMap = new List<GenderTranslate>();

        static TextEscaping()
        {
            //Pronomen der 3. Person  !!! Not perfect but maybe helpfull
            /* Personal Nom */
            genderTextMap.Add(new GenderTranslate("@er_sie", "er", "sie"));

            genderTextMap.Add(new GenderTranslate("@Er_Sie", "Er", "Sie"));

            /* Personal Dat */
            genderTextMap.Add(new GenderTranslate("@ihm_ihr", "ihm", "ihr"));
            genderTextMap.Add(new GenderTranslate("@Ihm_Ihr", "Ihm", "Ihr"));
            /* Possessiv Nom */
            genderTextMap.Add(new GenderTranslate("@sein_ihr", "sein", "ihr"));
            genderTextMap.Add(new GenderTranslate("@Sein_Ihr", "Sein", "Ihr"));
            genderTextMap.Add(new GenderTranslate("@seine_ihre", "seine", "ihre"));
            genderTextMap.Add(new GenderTranslate("@Seine_Ihre", "Seine", "Ihre"));

            /* Possessiv Akk */
            genderTextMap.Add(new GenderTranslate("@seinen_ihren", "seinen", "ihren"));
            genderTextMap.Add(new GenderTranslate("@Seinen_Ihren", "Seinen", "Ihren"));

            /* Possessiv Dat */
            genderTextMap.Add(new GenderTranslate("@seinem_ihrem", "seinem", "ihrem"));
            genderTextMap.Add(new GenderTranslate("@Seiner_Ihrer", "Seiner", "Ihrer"));

            /* Possessiv Gen */
            genderTextMap.Add(new GenderTranslate("@seines_ihres", "seines", "ihres"));
            genderTextMap.Add(new GenderTranslate("@Seines_Ihres", "Seines", "Ihres"));
        }

        public static String removeKeywords(String text, Lernende student)
        {
            if (text == null)
            {
                return null;
            }

            if (student == null)
            {
                return text;
            }

            text = text.Replace("@name", student.Vorname);
            text = text.Replace("@date", DateTime.Now.ToShortDateString());

            foreach (GenderTranslate item in genderTextMap)
            {
                text = text.Replace(item.getKey(), student.Gender == EnumGender.Male ? item.getMaleText() : item.getFemaleText());
            }

            return text;
        }

        public static String setKeywords(String text, String firstName)
        {
            if (text == null)
            {
                return null;
            }

            if (firstName != null)
            {
                text = text.Replace(firstName, "@name");
            }

            foreach (GenderTranslate item in genderTextMap)
            {
                text = replaceWord(text, item.getMaleText(), item.getKey());
                text = replaceWord(text, item.getFemaleText(), item.getKey());
            }

            return text;
        }

        private static String replaceWord(String input, String key, String replace)
        {
            if (replace == null)
            {
                replace = key;
            }
            // For uppercase

            var pattern = @"\b" + key + @"\b";
            input = new Regex(pattern).Replace(input, replace);

            return input;
        }
    }
}
