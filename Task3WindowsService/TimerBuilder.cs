using System.IO;
using System.Timers;

namespace Task3WindowsService
{
    /// <summary>
    /// Timer builder class
    /// </summary>
    public class TimerBuilder
    {
        // Index of the file being the number to be added to the file name
        private int i = 0;

        public Timer TimerObject;

        public TimerBuilder()
        {
            // Timer creation
            TimerObject = new Timer();
            TimerObject.Interval = 5000; // Timer start every 5 seconds
            TimerObject.Elapsed += (Sender, e) => OnTimerElapsed();
        }

        /// <summary>
        /// Create, rename and at list delete file in the current user temporary directory
        /// </summary>
        private void OnTimerElapsed()
        {
            string filePath;
            string newFilePath;

            // Create file name and search if file already exists
            do
            {
                filePath = Path.GetTempPath() + Properties.Resources.TemporaryFileName + ++i;
                newFilePath = filePath + "n";
            } while (File.Exists(filePath));

            // If file not exist
            if (!File.Exists(filePath))
            {
                // Creat new file
                using (File.Create(filePath))
                { }
                // Rename created file
                File.Move(filePath, newFilePath);
                // Delete created file
                File.Delete(newFilePath);
            }
        }
    }
}
