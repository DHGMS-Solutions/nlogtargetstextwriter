namespace NLog.Targets.TextWriter
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;

    using NLog.Targets;

    /// <summary>
    /// NLog Target for relaying events to a <see cref="T:System.IO.TextWriter">TextWriter</see>.
    /// </summary>
    [SuppressMessage("Usage", "Wintellect013:UseDebuggerDisplayAnalyzer", Justification = "Wrapper class with nothing useful")]
    public sealed class TextWriterTarget : TargetWithLayout
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed", Justification = "Text Writer is passed in from parent code that is responsilbe for disposing")]
        private readonly TextWriter _textWriter;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextWriterTarget"/> class.
        /// </summary>
        /// <param name="textWriter">The text writer to output log messages to.</param>
        /// <exception cref="ArgumentNullException">No text writer was passed.</exception>
        public TextWriterTarget(TextWriter textWriter)
        {
            this._textWriter = textWriter ?? throw new ArgumentNullException(nameof(textWriter));
            this.OptimizeBufferReuse = true;
        }

        /// <inheritdoc />
        protected override void Write(LogEventInfo logEvent)
        {
            var logMessage = this.RenderLogEvent(Layout, logEvent);

            this._textWriter.Write(logMessage);
        }
    }

}
