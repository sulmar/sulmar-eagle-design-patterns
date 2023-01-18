using System;
using System.Collections.Generic;
using System.Text;

namespace MementoPattern.Problem
{

    // Originator (inicjator)
    public class Article
    {
        public string Content { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }

        // Backup
        public ArticleMemento CreateMemento() => new ArticleMemento(Content, Title);

        // Restore
        public void SetMemento(ArticleMemento memento)
        {
            this.Title = memento.Title;
            this.Content = memento.Content;
        }
    }

    // Memento (migawka)
    public class ArticleMemento
    {
        public string Content { get; }
        public string Title { get;  }
        public DateTime SnapshotDate { get; }

        public ArticleMemento(string content, string title)
        {
            Content = content;
            Title = title;
            SnapshotDate = DateTime.Now;
        }
    }

    // Abstract Caretaker
    public interface IArticleCaretaker
    {
        ArticleMemento GetState();
        bool CanGetState { get; }
        void SetState(ArticleMemento memento);
    }

    // Concrete Caretaker
    public class LastArticleCaretaker : IArticleCaretaker
    {
        private ArticleMemento memento;
        public bool CanGetState => memento != null;
        public ArticleMemento GetState() => memento;
        public void SetState(ArticleMemento memento) => this.memento = memento;
    }

    public class StackArticleCaretaker : IArticleCaretaker
    {
        private Stack<ArticleMemento> mementos = new Stack<ArticleMemento>();
        public bool CanGetState => mementos.TryPeek(out _);
        public ArticleMemento GetState() => mementos.Pop();
        public void SetState(ArticleMemento memento) => mementos.Push(memento);
    }
}
