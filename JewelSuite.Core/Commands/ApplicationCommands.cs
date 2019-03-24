using Prism.Commands;

namespace JewelSuite.Core.Commands
{
    /// <summary>
    /// Aplication commands
    /// </summary>
    public interface IApplicationCommands
    {
        /// <summary>
        /// Gets the save command.
        /// </summary>
        /// <value>
        /// The save command.
        /// </value>
        CompositeCommand SaveCommand { get; }
    }

    /// <summary>
    /// Aplication commands
    /// </summary>
    /// <seealso cref="UsingCompositeCommands.Core.IApplicationCommands" />
    public class ApplicationCommands : IApplicationCommands
    {
        private CompositeCommand _saveCommand = new CompositeCommand();
        public CompositeCommand SaveCommand
        {
            get { return _saveCommand; }
        }
    }
}
