namespace Task3WindowsService
{
    public partial class FileWatcher
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer _components = null;

        private System.IO.FileSystemWatcher _fileSystemWatcher1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            // Clean resourses being used by File System Watcher
            if (disposing && (_components != null))
            {
                _components.Dispose();
            }
            // Clean resourses being used by Timer
            if (disposing && (_TimerBuilder.TimerObject != null))
            {
                _TimerBuilder.TimerObject.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this._fileSystemWatcher1)).BeginInit();
            // 
            // fileSystemWatcher1
            // 
            this._fileSystemWatcher1.EnableRaisingEvents = true;
            this._fileSystemWatcher1.IncludeSubdirectories = true;
            this._fileSystemWatcher1.NotifyFilter = ((System.IO.NotifyFilters)((((((((System.IO.NotifyFilters.FileName | System.IO.NotifyFilters.DirectoryName)
            | System.IO.NotifyFilters.Attributes)
            | System.IO.NotifyFilters.Size)
            | System.IO.NotifyFilters.LastWrite)
            | System.IO.NotifyFilters.LastAccess)
            | System.IO.NotifyFilters.CreationTime)
            | System.IO.NotifyFilters.Security)));
            this._fileSystemWatcher1.Path = System.IO.Path.GetTempPath();
            this._fileSystemWatcher1.Changed += WatcherOnChanged;
            this._fileSystemWatcher1.Created += WatcherOnCreated;
            this._fileSystemWatcher1.Deleted += WatcherOnDeleted;
            this._fileSystemWatcher1.Renamed += WatcherOnRenamed;
            this._fileSystemWatcher1.Error += WatcherOnError;
            // 
            // FileWatcher
            // 
            this.ServiceName = "Task3FileWatcher";
            ((System.ComponentModel.ISupportInitialize)(this._fileSystemWatcher1)).EndInit();
        }

        #endregion
    }
}
