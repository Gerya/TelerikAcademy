using System.Collections.Generic;
using System.Web.Http;
using StudentSystem.Model;

namespace StudentSystem.WebApi.Controllers
{
    public class StudentsController : BaseApiController
    {
        public StudentsController()
        {
        }

        [HttpGet]
        public IEnumerable<Student> GetAll()
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {

                var models = new List<Student>() { 

                    new Student(){
                        Id = 1,
                        FirstName = "John",
                        LastName = "Muller",
                        Age = 22,
                        Grade = 3,
                        Marks = new List<Mark>(){
                            new Mark(){
                                Subject = "History",
                                Value = 3
                            },
                            new Mark(){
                                Subject = "Mathematics",
                                Value = 6
                            },
                            new Mark(){
                                Subject = "Philosophy",
                                Value = 6
                            },
                            new Mark(){
                                Subject = "Literature",
                                Value = 6
                            },
                            new Mark(){
                                Subject = "History",
                                Value = 5
                            },
                            new Mark(){
                                Subject = "History",
                                Value = 6
                            },
                        }
                    },
                    new Student(){
                        Id = 2,
                        FirstName = "Anne",
                        LastName = "Richardson",
                        Age = 22,
                        Grade = 3,
                        Marks = new List<Mark>(){
                            new Mark(){
                                Subject = "History",
                                Value = 3
                            },
                            new Mark(){
                                Subject = "Mathematics",
                                Value = 6
                            },
                            new Mark(){
                                Subject = "Philosophy",
                                Value = 6
                            },
                            new Mark(){
                                Subject = "Literature",
                                Value = 6
                            },
                            new Mark(){
                                Subject = "History",
                                Value = 5
                            },
                            new Mark(){
                                Subject = "History",
                                Value = 6
                            },
                        }
                    },
                    new Student(){
                        Id = 3,
                        FirstName = "Mila",
                        LastName = "Ivanova",
                        Age = 22,
                        Grade = 3,
                        Marks = new List<Mark>(){
                            new Mark(){
                                Subject = "History",
                                Value = 3
                            },
                            new Mark(){
                                Subject = "Mathematics",
                                Value = 6
                            },
                            new Mark(){
                                Subject = "Philosophy",
                                Value = 6
                            },
                            new Mark(){
                                Subject = "Literature",
                                Value = 6
                            },
                            new Mark(){
                                Subject = "History",
                                Value = 5
                            },
                            new Mark(){
                                Subject = "History",
                                Value = 6
                            },
                        }
                    },
                    new Student(){
                        Id = 4,
                        FirstName = "Anton",
                        LastName = "Milanov",
                        Age = 22,
                        Grade = 3,
                        Marks = new List<Mark>(){
                            new Mark(){
                                Subject = "History",
                                Value = 3
                            },
                            new Mark(){
                                Subject = "Mathematics",
                                Value = 6
                            },
                            new Mark(){
                                Subject = "Philosophy",
                                Value = 6
                            },
                            new Mark(){
                                Subject = "Literature",
                                Value = 6
                            },
                            new Mark(){
                                Subject = "History",
                                Value = 5
                            },
                            new Mark(){
                                Subject = "History",
                                Value = 6
                            },
                        }
                    },
                    new Student(){
                        Id = 4,
                        FirstName = "Michael",
                        LastName = "Buchanan",
                        Age = 22,
                        Grade = 3,
                        Marks = new List<Mark>(){
                            new Mark(){
                                Subject = "History",
                                Value = 3
                            },
                            new Mark(){
                                Subject = "Mathematics",
                                Value = 6
                            },
                            new Mark(){
                                Subject = "Philosophy",
                                Value = 6
                            },
                            new Mark(){
                                Subject = "Literature",
                                Value = 6
                            },
                            new Mark(){
                                Subject = "History",
                                Value = 5
                            },
                            new Mark(){
                                Subject = "History",
                                Value = 6
                            },
                        }
                    },
                    new Student(){
                        Id = 5,
                        FirstName = "Thomas",
                        LastName = "Hardy",
                        Age = 22,
                        Grade = 3,
                        Marks = new List<Mark>(){
                            new Mark(){
                                Subject = "History",
                                Value = 3
                            },
                            new Mark(){
                                Subject = "Mathematics",
                                Value = 6
                            },
                            new Mark(){
                                Subject = "Philosophy",
                                Value = 6
                            },
                            new Mark(){
                                Subject = "Literature",
                                Value = 6
                            },
                            new Mark(){
                                Subject = "History",
                                Value = 5
                            },
                            new Mark(){
                                Subject = "History",
                                Value = 6
                            },
                        }
                    }
                };
                return models;
            });

            return responseMsg;
        }
    }
}
