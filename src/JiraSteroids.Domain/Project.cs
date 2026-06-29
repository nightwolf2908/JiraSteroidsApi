namespace JiraSteroids.Domain;

    public class Project
    {
        // 1. Identificador único
        public Guid Id { get; set; }
        // 2. Datos básicos del proyecto
        public string Name { get; set;} = string.Empty;
        public string Description { get; set; } = string.Empty;
        // 3. Fechas de control
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        // 4. Estado del proyecto
        public bool IsActive { get; set; } = true;
        // 5. Relación: Un proyecto contiene muchas tareas
        public List<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
