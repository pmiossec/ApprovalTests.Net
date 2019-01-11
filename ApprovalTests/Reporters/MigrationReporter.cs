using System.IO;
using ApprovalTests.Core;

namespace ApprovalTests.Reporters
{
    /// <summary>
    /// Reporter that replace the 'Accepted' file by the 'Received' file
    /// Should be used carefully, just when migrating to ApprovalTests or changing the format
    /// </summary>
    public class MigrationReporter : IEnvironmentAwareReporter
    {
        public static readonly MigrationReporter INSTANCE = new MigrationReporter();

        public void Report(string approved, string received)
        {
#if DEBUG
            File.Move(received, approved);
#endif
        }

        public bool IsWorkingInThisEnvironment(string forFile)
        {
            return true;
        }
    }
}