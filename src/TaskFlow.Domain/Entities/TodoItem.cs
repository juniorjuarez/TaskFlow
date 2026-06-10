using System;
using System.Collections.Generic;
using System.Text;

namespace TaskFlow.Domain.Entities;

public class TodoItem
{
    public Guid Id { get; private set; }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public int EstimatedMinutes { get; private set; }

    public bool IsCompleted { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public Guid GuidId { get; private set; }

    public User User { get; set; }

    public TodoItem(string title, string description, int estimatedMinutes)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("O título não pode ser vazio.");
        }

        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("A descrição detalhada da tarefa é obrigatória para suporte cognitivo.");
        }

        if (estimatedMinutes <= 0)
        {
            throw new ArgumentException("O tempo da tarefa precisa ser maior que zero, e não pode ser negativo.");
        }

        Id = Guid.NewGuid();

        Title = title;

        Description = description;

        EstimatedMinutes = estimatedMinutes;

        IsCompleted = false;

        CreatedAt = DateTime.UtcNow;
    }

    public void MarkIsCompleted()
    {
        IsCompleted = true;
    }

}
