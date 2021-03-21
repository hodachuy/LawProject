using LawProject.Domain.Common;
using LawProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Domain.Events.Questions
{
    public class QuestionCreatedEvent : DomainEvent
    {
        public QuestionCreatedEvent(Question question)
        {
            Question = question;
        }

        public Question Question { get; }
    }
}
