using System;
using System.Runtime.Serialization;

namespace ProjetPourTU.Services.CustomExceptions {
    internal class VehiculeNotFoundException : Exception {
        public VehiculeNotFoundException() {
        }

        public VehiculeNotFoundException(string message) : base(message) {
        }

        public VehiculeNotFoundException(string message, Exception innerException) : base(message, innerException) {
        }

        protected VehiculeNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}