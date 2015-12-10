using System.Threading.Tasks;

namespace BetteryMonitoringSystem.Common
{
    /// <summary>
    /// The TaskAgent interface.
    /// </summary>
    public interface ITaskAgent
    {
        #region Public Methods and Operators

        /// <summary>
        /// The task sync.
        /// </summary>
        /// <param name="access">
        /// The access.
        /// </param>
        void TaskAsync(Task access);

        /// <summary>
        /// The task sync window.
        /// </summary>
        /// <param name="access">
        /// The access.
        /// </param>
        void TaskSyncWindow(Task access);

        #endregion
    }
}