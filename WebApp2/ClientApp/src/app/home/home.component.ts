import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { Movie } from '../models/movie.model';
import { MovieService } from '../movie.service';
import { RoleGuard } from '../role.guard';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  isadmin: boolean = false;
  constructor(private movieService: MovieService, private role: RoleGuard) { }
   
  movies: Movie[]; 
  
  ngOnInit() {
    this.getMovies();
    this.isadmin = this.role.IsAdmin();
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
