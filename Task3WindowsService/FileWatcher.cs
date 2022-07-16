using System.Diagnostics;
using System.IO;
using System.ServiceProcess;

namespace Task3WindowsService
{
    /// <summary>
    /// File system watcher component logic
    /// </summary>
    public partial class FileWatcher : ServiceBase
    {
        /// <summary>
        /// Timer builder instance
        /// </summary>
        private TimerBuilder _TimerBuilder;

        public FileWatcher(TimerBuilder timerBuilder)
        {
            _TimerBuilder = timerBuilder;

            // Initialize component
            InitializeComponent();
        }

        /// <summary>
        /// OnStart event processing of the File System Watcher component as a service
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            // Write start entry into the system Event Log
            EventLog.WriteEntry("Сервис " + ServiceName.ToString() + " запущен.");

            // Run already created timer which creates files
            _TimerBuilder.TimerObject.Start();
        }

        /// <summary>
        /// OnStop event processing of the File System Watcher component as a service
        /// </summary>
        protected override void OnStop()
        {
            // Clear previously created entries for the service in the system Event Log
            EventLog.Clear();

            // Stop timer
            _TimerBuilder.TimerObject.Stop();
        }

        /// <summary>
        /// Event Changed processing of the File System Watcher component
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">FileSystemEventArgs</param>
        private void WatcherOnChanged(object sender, FileSystemEventArgs e)
        {
            // Process only changed file or folder
            if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                // Write entry when file or folder is changed
                EventLog.WriteEntry($"Изменён: {e.FullPath}");
            }
        }

        /// <summary>
        /// Event Created processing of the File System Watcher component
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">FileSystemEventArgs</param>
        private void WatcherOnCreated(object sender, FileSystemEventArgs e)
        {
            // Write entry when file or folder is changed
            EventLog.WriteEntry($"Создан: {e.FullPath}");
        }


        /// <summary>
        /// Event Deleted processing of the File System Watcher component
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">FileSystemEventArgs</param>
        private void WatcherOnDeleted(object sender, FileSystemEventArgs e)
        {
            // Write entry when file or folder is deleted
            EventLog.WriteEntry($"Удалён: {e.FullPath}");
        }

        /// <summary>
        /// Event Renamed processing of the File System Watcher component
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">RenamedEventArgs</param>
        private void WatcherOnRenamed(object sender, RenamedEventArgs e)
        {
            // Write entry when file or folder is renamed
            EventLog.WriteEntry($"Переименован из: {e.OldFullPath} в: {e.FullPath}");
        }

        /// <summary>
        /// Event Error processing of the File System Watcher component
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">ErrorEventArgs</param>
        private void WatcherOnError(object sender, ErrorEventArgs e) =>
            EventLog.WriteEntry(e.GetException().ToString());
    }
}
