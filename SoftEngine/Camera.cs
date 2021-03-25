using SharpDX;

namespace SoftEngine
{
    /// <summary>
    /// Camera class
    /// </summary>
    public class Camera
    {
        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public Vector3 Position { get; set; }

        /// <summary>
        /// Gets or sets the tartget.
        /// </summary>
        /// <value>
        /// The tartget.
        /// </value>
        public Vector3 Target { get; set; }
    }
}