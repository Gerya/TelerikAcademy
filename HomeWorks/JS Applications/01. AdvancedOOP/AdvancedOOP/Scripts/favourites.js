(function (me, undefined) {
    var Class = (function (me, undefined) {
        function createClass(properties) {
            var f = function () {
                this.init.apply(this, arguments);
            }
            for (var prop in properties) {
                f.prototype[prop] = properties[prop];
            }
            if (!f.prototype.init) {
                f.prototype.init = function () { }
            }
            return f;
        }

        Function.prototype.inherit = function (parent) {
            var oldPrototype = this.prototype;
            var prototype = new parent();
            this.prototype = Object.create(prototype);
            this.prototype._super = parent;
            for (var prop in oldPrototype) {
                this.prototype[prop] = oldPrototype[prop];
            }
        }

        return {
            create: createClass,
        };
    }());


    var Url = Class.create({
        init: function (title, source) {
            this.title = title;
            this.source = source;
        }
    });

    var Folder = Class.create({
        init: function (title) {
            this.title = title;
            this.urls = [];
        },
        addUrl: function (title, url) {
            var newUrl = new Url(title, url);
            this.urls.push(newUrl);
        }
    });

    me.FavouriteSitesBar = Class.create({
        init: function () {
            this.folders = [];
            this.urls = [];
        },
        createFolder: function (title) {
            var newFolder = new Folder(title);
            this.folders.push(newFolder);

            return newFolder;
        },
        display: function display(selector) {
            var element = document.querySelector(selector);
            var ul = document.createElement("ul");
            var li = document.createElement("li");
            var a = document.createElement("a");

            for (var i = 0; i < this.folders.length; i++) {
                var currentFolder = this.folders[i];
                var folderContainer = li.cloneNode(false);
                var folderName = document.createTextNode(currentFolder.title);
                folderContainer.appendChild(folderName);

                var urlsContainer = ul.cloneNode(false);
                for (var j = 0; j < this.folders[i].urls.length; j++) {
                    var currentUrl = this.folders[i].urls[j];
                    var urlName = document.createTextNode(currentUrl.title);
                    var urlAnchor = a.cloneNode(false);
                    urlAnchor.href = currentUrl.source;
                    urlAnchor.setAttribute("target", "_blank");
                    urlAnchor.appendChild(urlName);

                    var singleUrlContainer = li.cloneNode(false);
                    singleUrlContainer.appendChild(urlAnchor);
                    urlsContainer.appendChild(singleUrlContainer);
                }

                folderContainer.appendChild(urlsContainer);
                ul.appendChild(folderContainer);
            }

            element.appendChild(ul);
        }
    });
}(window.controls = window.controls || {}));