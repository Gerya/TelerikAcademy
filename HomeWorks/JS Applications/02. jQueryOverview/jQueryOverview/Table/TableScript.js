$(document).ready(function () {
    var Student = Class.create({
        initialize: function (firstName, lastName, grade) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.grade = grade;
        }
    });

    var Table = {
        init: function (selector) {
            this.selector = selector;
            this.students = [];
        },
        render: function () {
            $(this.selector).append("<thead>" +
                    "<tr>" +
                        "<th>First name</th>" +
                        "<th>Last name</th>" +
                        "<th>Grade</th>" +
                    "</tr>" +
                 "</thead>");
            var tbody = $("<tbody></tbody>");
            for (var i = 0, studentsCount = students.length; i < studentsCount; i++) {
                tbody.append("<tr>" +
                                "<td>" + students[i].firstName + "</td>" +
                                "<td>" + students[i].lastName + "</td>" +
                                "<td>" + students[i].grade + "</td>" +
                             "<tr>");
            }
            $(this.selector).append(tbody);
        },
        addStudents: function (students) {
            this.students = students;
        }
    }

    var students = [];
    students.push(new Student("Peter", "Milkov", 4));
    students.push(new Student("Milena", "Todorov", 3));
    students.push(new Student("Gergana", "Burkova", 12));
    students.push(new Student("Mitko", "Petrov", 7));
    students.push(new Student("Angel", "Marinov", 4));
    students.push(new Student("Miroslava", "Lilova",11));
    students.push(new Student("Mila", "Vankova", 3));
    students.push(new Student("Penka", "Lilova", 6));

    var table = Object.create(Table);
    table.init('#table-container');
    table.addStudents(students);
    table.render();
});