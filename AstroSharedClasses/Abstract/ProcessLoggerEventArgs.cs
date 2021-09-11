// <copyright file="ProcessLoggerEventArgs.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author>vl</author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Abstract {
    using JetBrains.Annotations;
    using System;

    /// <summary>
    /// Process Logger Event Args.
    /// </summary>
    public sealed class ProcessLoggerEventArgs : EventArgs {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the ProcessLoggerEventArgs class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">Passed message.</param>
        /// <param name="percentage">The percentage.</param>
        public ProcessLoggerEventArgs(string title, string message, int percentage) {
            this.Title = title;
            this.Message = message;
            this.Percentage = percentage;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessLoggerEventArgs"/> class.
        /// </summary>
        [UsedImplicitly]
        public ProcessLoggerEventArgs() {    
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <value>
        /// Property description.
        /// </value>
        public string Title { get; }

        /// <summary>
        /// Gets Message.
        /// </summary>
        /// <value> Property description. </value>/// 
        public string Message { get; }

        /// <summary>
        /// Gets the percentage.
        /// </summary>
        /// <value>
        /// The percentage.
        /// </value>
        public int Percentage { get; }
        #endregion
    }
}
