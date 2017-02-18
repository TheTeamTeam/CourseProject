using System;

namespace CourseProject.Mvp.CommonEventArguments
{
    public class IdEventArgs : EventArgs
    {
        public IdEventArgs(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }
    }
}