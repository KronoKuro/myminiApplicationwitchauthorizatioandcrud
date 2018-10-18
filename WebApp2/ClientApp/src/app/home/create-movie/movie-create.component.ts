import { MovieService } from "../../movie.service";
import { Movie } from "../../models/movie.model";
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

@Component({
  selector: 'app-add-movie',
  templateUrl: './movie-create.component.html',
  styleUrls: ['./movie-create.component.css']
})
export class CreateMovieComponent {
  debbuger;
  constructor(private movieServices: MovieService, private router: Router) {
    this.movieForm = new FormGroup({
      'Name': new FormControl('', [Validators.required, Validators.maxLength(250)]),
      'Description': new FormControl('', Validators.required),
      'ReleaseDate': new FormControl('', Validators.required),
    })
  }

  movieForm: FormGroup;

  Item: Movie;

  //formControl = new FormControl('', [Validators.required]);

  addItem() {
    debugger;
    this.movieServices.addMovie(this.movieForm.getRawValue()).subscribe(resp => { });
    this.router.navigate(['home']);
  }

}
