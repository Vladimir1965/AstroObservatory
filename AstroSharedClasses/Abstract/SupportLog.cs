﻿// <copyright file="SupportLog.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author>vl</author>
// <email></email>
// <date>2009-02-01</date>
// <summary>BwPort</summary>

namespace AstroSharedClasses.Abstract {
    using System;
    using System.Diagnostics.Contracts;
    using System.IO;
    using System.Xml.Serialization;

    /// <summary>
    /// Support Log.
    /// </summary>
    [XmlRoot]
    public sealed class SupportLog : IDisposable {
        #region Fields
        /// <summary> Log file stream. </summary>
        private FileStream logStream; //// = null;

        /// <summary> Log stream writer. </summary>
        private StreamWriter swlog; //// = null;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the SupportLog class. 
        /// </summary>
        /// <param name="givenDirectory">Given Directory.</param>
        public SupportLog(string givenDirectory) {
            this.CurrentDirectory = givenDirectory;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets log writer.
        /// </summary>
        /// <value> Property description. </value>
        //// [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Contracts", "Ensures")]
        public StreamWriter Swlog {
            get {
                Contract.Ensures(Contract.Result<StreamWriter>() != null);
                if (this.swlog == null) {
                    throw new InvalidOperationException("Stream Writer is null.");
                }

                return this.swlog;
            }
        }

        /// <summary>
        /// Gets LogStream.
        /// </summary>
        /// <value> Property description. </value>
        public FileStream LogStream {
            get {
                Contract.Ensures(Contract.Result<FileStream>() != null);
                if (this.logStream == null) {
                    throw new InvalidOperationException("File Stream is null.");
                }

                return this.logStream;
            }
        }

        /// <summary>
        /// Gets or sets CurrentDirectory.
        /// </summary>
        /// <value> Property description. </value>
        public string CurrentDirectory { get; set; }
        #endregion

        #region Dispose
        /// <summary>
        /// Dispose object.
        /// </summary>
        public void Dispose() {
            this.Dispose(true);
            //// GC.SuppressFinalize(this);  // Violates rule // true
        }
        #endregion

        #region Logs
        /// <summary>
        /// Open Log file.
        /// </summary>
        /// <param name="logFileName">Log File Name.</param>
        public void OpenLog(string logFileName) {
            Contract.Requires(logFileName != null);
            Contract.Requires(this.CurrentDirectory != null);

            var path = Path.Combine(this.CurrentDirectory, logFileName);
            if (string.IsNullOrEmpty(path)) {
                return;
            }

            this.logStream = new FileStream(
                        path,
                        FileMode.OpenOrCreate,
                        FileAccess.ReadWrite,
                        FileShare.None);
            this.swlog = new StreamWriter(this.logStream);
        }

        /// <summary>
        /// Write Message. 
        /// </summary>
        /// <param name="message">String message.</param>
        public void WriteMessage(string message) {
            Contract.Requires(message != null);
            if (message == null) {
                return;
            }

            this.LogStream.Seek(0, SeekOrigin.End); // go to the end
            this.Swlog.AutoFlush = true;
            this.Swlog.WriteLine(message.Trim());
        }

        /// <summary> Close Log. </summary>
        public void CloseLog() {
            //// try {
            this.Swlog.Close();
            this.LogStream.Close();
            //// } catch {
            //// }
        }
        #endregion     

        #region Dispose
        /// <summary>
        /// Dispose object.
        /// </summary>
        /// <param name="disposing">Disposing indicator.</param>
        private void Dispose(bool disposing) { //// virtual
            if (!disposing)
            {
                return;
            }

            if (this.logStream != null) {
                this.logStream.Dispose();
                this.logStream = null;
            }

            if (this.swlog == null)
            {
                return;
            }

            this.swlog.Dispose();
            this.swlog = null;
        }
        #endregion
    }
}