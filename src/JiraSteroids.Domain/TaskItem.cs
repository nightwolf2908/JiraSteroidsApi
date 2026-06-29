namespace JiraSteroids.Domain;

public class TaskItem
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    // 1. Uso de un "Enum" para el estado de la tarea
    public TaskStatus Status { get; set; } = TaskStatus.ToDo;

    // 2. Fechas de control
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? DueDate { get; set; } // Fecha de vencimiento (opcional)

    // 3. RELACIÓN: ¿A qué proyecto pertenece esta tarea?
    public Guid ProjectId { get; set; } // Clave foránea (Foreign Key)
    public Project Project { get; set; } = null!; // Propiedad de navegación
}

// 4. Definición del Enum (Estados posibles de una tarea)
public enum TaskStatus
{
    ToDo,        // Por hacer
    InProgress,  // En progreso
    InReview,    // En revisión
    Done         // Terminada
}