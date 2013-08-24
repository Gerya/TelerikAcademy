using Students.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Students.Services.Controllers
{
    public class StudentsController : BaseApiController
    {
        private List<Student> students;

        public StudentsController()
        {
            students = new List<Student>() { 

                    new Student(){
                        Id = 1,
                        Name = "John Muller",
                        Grade = 3,
                        Marks = new List<Mark>(){
                            new Mark(){
                                Subject = "History",
                                Score = 3
                            },
                            new Mark(){
                                Subject = "Mathematics",
                                Score = 6
                            },
                            new Mark(){
                                Subject = "Philosophy",
                                Score = 6
                            },
                            new Mark(){
                                Subject = "Literature",
                                Score = 6
                            },
                            new Mark(){
                                Subject = "History",
                                Score = 5
                            },
                            new Mark(){
                                Subject = "History",
                                Score = 6
                            }
                        }
                    },
                    new Student(){
                        Id = 2,
                        Name = "Anne Richardson",
                        Grade = 3,
                        Marks = new List<Mark>(){
                            new Mark(){
                                Subject = "History",
                                Score = 3
                            },
                            new Mark(){
                                Subject = "Mathematics",
                                Score = 6
                            },
                            new Mark(){
                                Subject = "Philosophy",
                                Score = 6
                            },
                            new Mark(){
                                Subject = "Literature",
                                Score = 6
                            },
                            new Mark(){
                                Subject = "History",
                                Score = 5
                            },
                            new Mark(){
                                Subject = "History",
                                Score = 6
                            }
                        }
                    },
                    new Student(){
                        Id = 3,
                        Name = "Mila Ivanova",
                        Grade = 5,
                        Marks = new List<Mark>(){
                            new Mark(){
                                Subject = "History",
                                Score = 3
                            },
                            new Mark(){
                                Subject = "Mathematics",
                                Score = 6
                            },
                            new Mark(){
                                Subject = "Philosophy",
                                Score = 6
                            },
                            new Mark(){
                                Subject = "Literature",
                                Score = 6
                            },
                            new Mark(){
                                Subject = "History",
                                Score = 5
                            },
                            new Mark(){
                                Subject = "History",
                                Score = 6
                            }
                        }
                    },
                    new Student(){
                        Id = 4,
                        Name = "Anton Milanov",
                        Grade = 3,
                        Marks = new List<Mark>(){
                            new Mark(){
                                Subject = "History",
                                Score = 3
                            },
                            new Mark(){
                                Subject = "Mathematics",
                                Score = 6
                            },
                            new Mark(){
                                Subject = "Philosophy",
                                Score = 6
                            },
                            new Mark(){
                                Subject = "Literature",
                                Score = 6
                            },
                            new Mark(){
                                Subject = "History",
                                Score = 5
                            },
                            new Mark(){
                                Subject = "History",
                                Score = 6
                            }
                        }
                    },
                    new Student(){
                        Id = 5,
                        Name = "Michael Buchanan",
                        Grade = 3,
                        Marks = new List<Mark>(){
                            new Mark(){
                                Subject = "History",
                                Score = 3
                            },
                            new Mark(){
                                Subject = "Mathematics",
                                Score = 6
                            },
                            new Mark(){
                                Subject = "Philosophy",
                                Score = 6
                            },
                            new Mark(){
                                Subject = "Literature",
                                Score = 6
                            },
                            new Mark(){
                                Subject = "History",
                                Score = 5
                            },
                            new Mark(){
                                Subject = "History",
                                Score = 6
                            }
                        }
                    },
                    new Student(){
                        Id = 6,
                        Name = "Thomas Hardy",
                        Grade = 3,
                        Marks = new List<Mark>(){
                            new Mark(){
                                Subject = "History",
                                Score = 3
                            },
                            new Mark(){
                                Subject = "Mathematics",
                                Score = 6
                            },
                            new Mark(){
                                Subject = "Philosophy",
                                Score = 6
                            },
                            new Mark(){
                                Subject = "Literature",
                                Score = 6
                            },
                            new Mark(){
                                Subject = "History",
                                Score = 5
                            },
                            new Mark(){
                                Subject = "History",
                                Score = 6
                            }
                        }
                    }
                };
        }

        [HttpGet]
        public IEnumerable<Student> GetAll()
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var result =
                    from student in students
                    select new Student
                    {
                        Id = student.Id,
                        Name = student.Name,
                        Grade = student.Grade,
                    };

                return result;
            });

            return responseMsg;
        }

        [HttpGet]
        [ActionName("detailed")]
        public IEnumerable<Student> GetAllDetailed()
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                return students;
            });

            return responseMsg;
        }

        [HttpGet]
        [ActionName("marks")]
        public Student GetMarks(int studentId)
        {
            var student = students.FirstOrDefault(s => s.Id == studentId);

            if (student == null)
            {
                throw new ArgumentException("Invalid student Id.");
            }

            return student;
        }
    }
}
