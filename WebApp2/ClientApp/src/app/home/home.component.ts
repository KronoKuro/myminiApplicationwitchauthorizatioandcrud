import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { Movie } from '../models/movie.model';
import { MovieService } from '../movie.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private movieService: MovieService) { }

  movies: Movie[]; 
  
  ngOnInit() {
    this.getMovies();
  }

  getMovies() {
    this.movieService.getMovies().subscribe(resp => {
      this.movies = resp;
    });
  }

  deleteMovie(id: string) {
    this.movieService.deleteMovie(id).subscribe(resp => {
      alert('Movies deleted');
      this.getMovies();
    });
  }
}
