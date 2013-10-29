var Class = (function() {
    function createClass(properties) {
        var f = function () {
            if(this._superConstructor){
                this._super = new this._superConstructor(arguments);
            }
            this.init.apply(this, arguments);
        }
        for (var prop in properties) {
            f.prototype[prop] = properties[prop];
        }
        if (!f.prototype.init) {
            f.prototype.init = function() {}
        }
        return f;
    }

    Function.prototype.inherit = function(parent) {
        var oldPrototype = this.prototype;
        this.prototype = new parent();
        this.prototype._superConstructor = parent;
        for (var prop in oldPrototype) {
            this.prototype[prop] = oldPrototype[prop];
        }
    }

    return {
        create: createClass,
    };
}());


var Person = Class.create({
    init: function (fname, lname, age) {
        this.fname = fname;
        this.lname = lname;
        this.age = age;
    },
    toString: function () {
        return "Name: " + this.fname + " " + this.lname + ", age: " + this.age;
    }
});

var Teacher = Class.create({
    init: function (fname, lname, age, speciality) {

        this._super.init(fname, lname, age);
        this.speciality = speciality;
    },
    introduce: function () {
        return this._super.toString() + ", has " + this.speciality + " speciality";
    }
});

var Student = Class.create({
    init: function (fname, lname, age, grade) {

        this._super.init(fname, lname, age);
        this.grade = grade;
    },
    introduce: function () {
        return this._super.toString() + ", in " + this.grade + " grade";
    }
});

Teacher.inherit(Person);
Student.inherit(Person);

var School = Class.create({
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

var Course = Class.create({
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