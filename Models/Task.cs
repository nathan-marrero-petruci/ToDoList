using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    // Representa uma tarefa da lista To Do
    public class Task
    {
        // Identificador único da tarefa
        public int Id { get; set; }

        // Título da tarefa (obrigatório)
        [Required(ErrorMessage = "O título é obrigatório.")]
        [StringLength(100, ErrorMessage = "O título deve ter até 100 caracteres.")]
        public string? Title { get; set; }

        // Descrição da tarefa (opcional)
        public string? Description { get; set; }

        // Indica se a tarefa foi concluída
        public bool IsCompleted { get; set; }

        // Data em que a tarefa foi concluída (opcional)
        public DateTime? CompletedAt { get; set; }

        // Data da última atualização da tarefa
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Data de criação da tarefa
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
