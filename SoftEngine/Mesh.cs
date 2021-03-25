using SharpDX;

namespace SoftEngine
{
    /// <summary>
    /// Mesh Class
    /// </summary>
    public class Mesh
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the vertices.
        /// </summary>
        /// <value>
        /// The vertices.
        /// </value>
        public Vector3[] Vertices { get; private set; }

        /// <summary>
        /// Gets or sets the faces.
        /// </summary>
        /// <value>
        /// The faces.
        /// </value>
        public Face[] Faces { get; set; }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public Vector3 Position { get; set; }

        /// <summary>
        /// Gets or sets the rotation.
        /// </summary>
        /// <value>
        /// The rotation.
        /// </value>
        public Vector3 Rotation { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mesh"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="verticesCount">The vertices count.</param>
        /// <param name="facesCount">The faces count.</param>
        public Mesh(string name, int verticesCount, int facesCount)
        {
            Vertices = new Vector3[verticesCount];
            Faces = new Face[facesCount];
            Name = name;
        }
    }
}