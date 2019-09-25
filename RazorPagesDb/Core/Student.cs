using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace RazorPagesDb.Core
{
    //сущность класса должна быть в единственном числе (это одна строка в базе)
    public class Student
    {
        /// Для валидации полей используем аннотации
        /// ISMODEL.VALID больше не нужен, просто указываем сущность в post методе
        /// Сообщение о херовой валидации вернет сам ef
        /// Дальше в проектировке веба ты будешь делать отделную папку Model в ней будут теже классы что и в Core
        /// Но данные будут ограничены (чтобы пользакам лишние данные не отдавать) и аннотации будут в моделях,
        /// а сущности будут чистыми, только описания полей и связей
        [Required]
        public int Id { get; set; }
        [NotNull]
        public string LastName { get; set; }
        [NotNull, MaxLength(250)] //можно несколько
        public string FirstName { get; set; }
        
        [DataType(DataType.Date)] //Только дата
        public DateTime EnrollmentDate { get; set; }

        public ICollection<Homework> Homeworks { get; set; }
    }
}