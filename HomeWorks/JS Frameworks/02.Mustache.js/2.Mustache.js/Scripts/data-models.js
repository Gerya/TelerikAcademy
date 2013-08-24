var dataModels = (function () {
    var Person = Class.create({
        init: function (firstName, lastName, age) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        },

        getFullName: function () {
            return this.firstName + " " + this.lastName;
        }
    });

    var Mark = Class.create({
        init: function (subject, value) {
            this.subject = subject;
            this.value = value;
        }
    });

    var Student = Person.extend({
        init: function (id, firstName, lastName, age, grade, marks) {
            this._super(firstName, lastName, age);
            this.grade = grade;
            this.marks = marks;
            this.id = id;
        }
    });

    var students = [
        new Student(5, "John", "Fuller", 21, 4, [
            new Mark("History", 3),
            new Mark("Mathematics", 6),
            new Mark("Philosophy", 6),
            new Mark("Literature", 6),
            new Mark("History", 5),
            new Mark("History", 6)]),
        new Student(3, "Nancy", "Davolio", 29, 1, [
            new Mark("History", 3),
            new Mark("Mathematics", 5),
            new Mark("Philosophy", 3)]),
        new Student(90, "Margaret", "Peacock", 18, 3, [
            new Mark("History", 6),
            new Mark("Mathematics", 6),
            new Mark("Philosophy", 5),
            new Mark("Literature", 3)]),
        new Student(100, "Anne", "Richardson", 24, 4, [
            new Mark("History", 2),
            new Mark("Mathematics", 4),
            new Mark("Philosophy", 3),
            new Mark("Literature", 5),
            new Mark("History", 3)]),
        new Student(23, "Peter", "Buchanan", 38, 2, [
            new Mark("History", 6),
            new Mark("Mathematics", 6),
            new Mark("Philosophy", 5),
            new Mark("Literature", 3)]),
        new Student(44, "Michael", "Douglas", 27, 4, [
            new Mark("Mathematics", 6)])
    ];

    return {
        Student: Student,
        Mark: Mark,
        students: students
    };
})();
