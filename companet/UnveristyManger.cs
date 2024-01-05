﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyUnversity
{
    public class UnveristyManger
    {
        private string name;
        private Subject[] subjectArray = new Subject[5];
        private Dean[] deanArray = new Dean[5];
        private Security[] securityArray = new Security[5];
        private Professor[] professorArray = new Professor[10];
        private Student[] studentArray = new Student[10];
        private StudentSubject[] studentSubjectArray = new StudentSubject[10];
        private int studentSubjectIndex = 0;
        private int studentIndex = 0;
        private int professorIndex = 0;
        private int securityIndex = 0;
        private int deanIndex = 0;
        private int subIndex = 0;
        private int generalId = 1;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
        public string Address { get; set; }

        //getBySubjectName
        public Subject getBySubjectName(string name)
        {
            foreach (Subject subject in subjectArray)
            {
                if (subject != null && subject.Name.Equals(name))
                {
                    return subject;
                }
            }

            return null;
        }

        // createSubject
        public Subject createSubject(string name, int semester)
        {
            Subject exist = getBySubjectName(name);
            if (exist != null)
            {
                System.Console.WriteLine("sorry bu fan oldindan mavjud!!!");
                return null;
            }

            Subject subject = new Subject();
            subject.Name = name;
            subject.Semester = semester;
            subjectArray[subIndex++] = subject;
            subject.Id = generalId++;
            return subject;
        }
        //getSubjectId
        public Subject getSubjectById(int id)
        {
            foreach (Subject subject in subjectArray)
            {
                if (subject != null && subject.Id.Equals(id))
                {
                    return subject;
                }
            }
            return null;
        }

        //getSubjectByName
        public Subject getSubjectByName(string name)
        {

            foreach (Subject subject in subjectArray)
            {
                if (subject != null && subject.Name.Equals(name))
                {
                    return subject;
                }
            }
            return null;
        }

        //createDean
        public Dean createDean(string name, string surname, int age, string birthDate, string faculty, double salary)
        {
            Dean exist = getDeanByFaculty(faculty);
            if (exist != null)
            {
                return null;
            }

            Dean dean = new Dean();
            dean.Id = generalId++;
            dean.Name = name;
            dean.Surname = surname;
            dean.Age = age;
            dean.BirthDate = birthDate;
            dean.Faculty = faculty;
            dean.Salary = salary;
            dean.CreatedDate = DateTime.Now;
            deanArray[deanIndex++] = dean;
            return dean;
        }

        //getDeanById
        public Dean getDeanById(int id)
        {
            foreach (Dean dean in deanArray)
            {
                if (dean != null && dean.Id.Equals(id))
                {
                    return dean;
                }
            }

            return null;
        }

        //getDeanByFaculty
        public Dean getDeanByFaculty(string faculty)
        {
            foreach (Dean dean in deanArray)
            {
                if (dean != null && dean.Faculty.Equals(faculty))
                {
                    return dean;
                }
            }
            return null;
        }

        // getDeanEmployeedDateById
        public DateTime getDeanEmployeedDateById(int id)
        {
            foreach (Dean dean in deanArray)
            {
                if (dean != null && dean.Id.Equals(id))
                {
                    return dean.CreatedDate;
                }
            }

            return DateTime.Now;
        }

        // createSecurty
        public Security createSecurity(string name, string surname, int age, string birthDate, double salary, string militaryRank)
        {
            Security exist = getSecurityByName(name);
            if (exist != null && exist.Name.Equals(name))
            {
                System.Console.WriteLine("Sorry this securty already exist!!");
            }
            Security security = new Security();
            security.Id = generalId++;
            security.Name = name;
            security.Surname = surname;
            security.Age = age;
            security.BirthDate = birthDate;
            security.Salary = salary;
            security.MilitaryRank = militaryRank;
            securityArray[securityIndex++] = security;
            return security;
        }

        //getSecurtyByName
        public Security getSecurityByName(string name)
        {
            foreach (Security security in securityArray)
            {
                if (security != null && security.Name.Equals(name))
                {
                    return security;
                }
            }
            return null;
        }

        public Security[] getSecurityListByMilitaryRank(string militaryRank)
        {
            Security[] securities = new Security[securityArray.Length];
            int i = 0;
            foreach (Security exist in securityArray)
                if (exist != null && exist.MilitaryRank.Equals(militaryRank))
                {
                    securities[i++] = exist;
                }
            return securities;
        }
        //createProfessor
        public Professor createProfessor(string name, string surname, int age, string birthDate, double salary, int subjectId)
        {
            Professor professor = new Professor();
            professor.Id = generalId++;
            professor.Name = name;
            professor.Surname = surname;
            professor.Age = age;
            professor.BirthDate = birthDate;
            professor.Salary = salary;
            professor.subject.Id = subjectId;
            professorArray[professorIndex++] = professor;
            return professor;

        }

        public Professor getProfessorById(int id)
        {
            foreach (Professor professor in professorArray)
            {
                if (professor != null && professor.Id.Equals(id))
                {
                    return professor;
                }
            }

            return null;
        }


        //createStudent
        public Student createStudent(string name, string surname, int age, DateTime birthDate, int level)
        {
            Student student = new Student();
            student.id = generalId++;
            student.name = name;
            student.surname = surname;
            student.age = age;
            student.birthDate = birthDate;
            student.level = level;
            studentArray[studentIndex++] = student;
            return student;
        }
        // addSubjectToStudent
        public Student addSubjectToStudent(int studentId, int subjectId)
        {
            StudentSubject studentSubject = new StudentSubject(studentId, subjectId);
            Student student = getStudentById(studentId);
            Subject subject = getSubjectById(subjectId);

            if (student == null || subject == null)
            {
                System.Console.WriteLine("student yoki subject mavjud emas!!!");
                return null;
            }
            studentSubjectArray[studentSubjectIndex++] = studentSubject;
            return student;
        }
        //getStudentById
        public Student getStudentById(int studentId)
        {
            foreach (var student in studentArray)
            {
                if (student != null && student.id.Equals(studentId))
                {
                    return student;
                }
            }

            return null;
        }
        //getStudentListByLevel
        public Student[] getStudentListByLevel(int level)
        {
            Student[] newArray = new Student[studentArray.Length];
            int i = 0;
            foreach (var item in studentArray)
            {
                if (item != null && item.level.Equals(level))
                {
                    newArray[i++] = item;
                }
            }
            return newArray;
        }

        //getStudentListBySubjectId
        public Student[] getStudentListBySubjectId(int subjectId)
        {
            Student[] temp = new Student[studentSubjectArray.Length];
            int i = 0;
            foreach (StudentSubject item in studentSubjectArray)
            {
                if (item != null && item.SubjectId.Equals(subjectId))
                {
                    Student student = getStudentById(item.StudentId);
                    temp[i++] = student;
                }
            }

            return temp;
        }
    }
}
