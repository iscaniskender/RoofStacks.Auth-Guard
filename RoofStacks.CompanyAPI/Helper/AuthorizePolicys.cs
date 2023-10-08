namespace RoofStacks.CompanyAPI.Helper
{
    /// <summary>
    /// Provides constants for policy names used for authorization in controllers.
    /// This static class serves as a centralized location for defining and managing policy names,
    /// making it easier to maintain and update them across the application.
    /// </summary>
    public static class AuthorizePolicys
    {
        /// <summary>
        /// Represents the "Read" policy, typically allowing data retrieval operations.
        /// </summary>
        public const string Read = "Read";

        /// <summary>
        /// Represents the "Write" policy, typically allowing data modification operations.
        /// </summary>
        public const string Write = "Write";

        /// <summary>
        /// Represents the "Delete" policy, typically allowing data removal operations.
        /// </summary>
        public const string Delete = "Delete";
    }
}
