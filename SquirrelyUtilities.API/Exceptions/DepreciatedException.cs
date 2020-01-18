using System;

namespace SquirrelyUtilities.API.Exceptions {
    public class DepreciatedException : Exception {
        public DepreciatedException() {

        }

        public DepreciatedException(string oldMethod, string newMethod) : base($"{oldMethod} Has been depreciated please use {newMethod}") {

        }
    }
}
