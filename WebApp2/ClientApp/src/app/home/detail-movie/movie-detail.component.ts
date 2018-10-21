import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Router, ActivatedRoute } from '@angular/router';
import { Movie } from '../../models/movie.model';
import { MovieService } from '../../movie.service';




@Component({
  selector: 'app-detail-movie',
  templateUrl: './movie-detail.component.html',
  styleUrls: ['./movie-detail.component.css']
})


export class MovieDetailComponent implements OnInit {

  constructor(private movieService: MovieService, router: Router, private activateRouter: ActivatedRoute) { }

  movie: Movie;
  
  ngOnInit() {
    const id = this.activateRouter.snapshot.paramMap.get('id');
    this.getMovie(id);

  }

  getMovie(id: string) {
    debugger;
    this.movieService.getMovie(id).subscribe((movie: Movie) => {
      this.movie = movie;
    });
  }

}
