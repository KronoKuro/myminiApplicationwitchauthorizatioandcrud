import { Component, OnInit } from "@angular/core";
import { GenresServices } from '../genres.services';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-genres',
  templateUrl: './genre.component.html',
  //styleUrls: ['./news.component.css']
})
export class GenreComponent implements OnInit {

  movies: any;

  constructor(private genreService: GenresServices, private activateRouter: ActivatedRoute) {
   
    
  }

  ngOnInit() {
    const id = this.activateRouter.snapshot.paramMap.get('id');
    this.getGenresMovieById(id);
    
  }

  getGenresMovieById(id: string) {
    debugger;
    this.genreService.getGenreById(id).subscribe(resp => {
      if (this.movies != null) {
        this.movies = resp;
        console.log(this.movies);
        location.reload();
      } else {
        this.movies = resp;
        console.log(this.movies);
      }
    });
  }

}
