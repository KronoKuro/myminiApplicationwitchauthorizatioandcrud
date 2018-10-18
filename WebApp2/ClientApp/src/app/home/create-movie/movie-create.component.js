"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var forms_1 = require("@angular/forms");
var CreateMovieComponent = /** @class */ (function () {
    function CreateMovieComponent(movieServices, movie) {
        this.movieServices = movieServices;
        this.movie = movie;
        this.formControl = new forms_1.FormControl('', [forms_1.Validators.required]);
        this.movieForm = new forms_1.FormGroup({
            'Name': new forms_1.FormControl('', [forms_1.Validators.required, forms_1.Validators.maxLength(250)]),
            'Description': new forms_1.FormControl('', forms_1.Validators.required),
            'RealiseDate': new forms_1.FormControl('', forms_1.Validators.required),
        });
    }
    CreateMovieComponent.prototype.ngOnInit = function () {
    };
    CreateMovieComponent.prototype.addItem = function () {
        this.movieServices.addMovie(this.movieForm.getRawValue().subscribe(function (resp) { }));
    };
    return CreateMovieComponent;
}());
exports.CreateMovieComponent = CreateMovieComponent;
//# sourceMappingURL=movie-create.component.js.map