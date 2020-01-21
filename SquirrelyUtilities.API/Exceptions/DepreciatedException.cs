using System;

namespace SquirrelyUtilities.API.Exceptions {
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class DepreciatedException : Exception {
        /// <summary>
        /// Initializes a new instance of the <see cref="DepreciatedException"/> class.
        /// </summary>
        public DepreciatedException() {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DepreciatedException"/> class.
        /// </summary>
        /// <param name="oldMethod">The old method.</param>
        /// <param name="newMethod">The new method.</param>
        public DepreciatedException(string oldMethod, string newMethod) : base($"{oldMethod} Has been depreciated please use {newMethod}") {

        }
    }
}
