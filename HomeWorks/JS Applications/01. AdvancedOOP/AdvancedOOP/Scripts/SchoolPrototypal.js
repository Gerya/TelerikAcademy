(function (undefined) {
    if (!Object.create) {
        Object.create = function (obj) {
            function f() { };
            f.prototype = obj;
            return new f();
        }
    }

    Object.prototype.extend = function (properties) {
        function f() { };
        f.prototype = Object.create(this);
        for (var prop in properties) {
            f.prototype[prop] = properties[prop];
        }
        f.prototype._super = this;
        return new f();
    }
}());

var Person ={
    init: function (fname, lname, age) {
        this.fname = fname;
        this.lname = lname;
        this.age = age;
    },
    toString: function () {
        return "Name: " + this.fname + " " + this.lname + ", age: " + this.age;
    }
};

var Teacher = Person.extend({
    init: function (fname, lname, age, speciality) {

        Person.init.call(this,fname, lname, age);
        this.speciality = speciality;
    },
    introduce: function () {
        return Person.toString.apply(this) + ", has " + this.speciality + " speciality";
    }
});

var Student = Person.extend({
    init: function (fname, lname, age, grade) {

        Person.init.call(this,fname, lname, age);
        this.grade = grade;
    },
    introduce: function () {
        return Person.toString.apply(this) + ", in " + this.grade + " grade";
    }
});

var School = ({
    init: function (name, town, classes) {
        this.name = name;
        this.town = town;
        this.classes = classes;
    },
    introduce: function () {
        var str = "Name:" + this.name + ", Town:" + this.town + ", Classes:";
        for (var i = 0; i < this.classes.length; i++) {
            str += this.classes[i].name + ", ";
        }
        return str.substr(0, str.length - 2);
    }
});

var Course = ({
    init: function (name, capacity, students, formTeacher) {
        this.name = name;
        this.capacity = capacity;
        this.students = students;
        this.formTeacher = formTeacher;
    },
    introduce: function () {
        var str = "Name:" + this.name + ", Capacity:" + this.capacity + ", Students:";
        for (var i = 0; i < this.students.length; i++) {
            str += this.students[i].introduce() + ", ";
        }
        str += "Form-teacher" + this.formTeacher.introduce();
        return str;
    }
});
