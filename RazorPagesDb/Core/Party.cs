using System;

namespace RazorPagesDb.Core
{

    public class Homework
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}