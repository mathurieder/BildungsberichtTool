using System;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using ToastNotifications.Messages;
using System.Windows;

namespace BildungsberichtTemplate
{
    public static class Message
    {
        private static Notifier notifier = new Notifier(cfg =>
        {
            cfg.PositionProvider = new WindowPositionProvider(
                parentWindow: Application.Current.MainWindow,
                corner: Corner.TopRight,
                offsetX: 10,
                offsetY: 10);

            cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                notificationLifetime: TimeSpan.FromSeconds(3),
                maximumNotificationCount: MaximumNotificationCount.FromCount(5));

            cfg.Dispatcher = Application.Current.Dispatcher;
        });

        public static void ShowWarning(String message) {
            notifier.ShowWarning(message);
        }

        public static void ShowSuccess(String message)
        {
            notifier.ShowSuccess(message);
        }

        public static void ShowInformation(String message)
        {
            notifier.ShowInformation(message);
        }

        public static void ShowError(String message)
        {
            notifier.ShowError(message);
        }
    }
}
