import { Component, OnInit, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { Router, ActivatedRoute } from '@angular/router';
import { Movie } from '../../models/movie.model';
import { MovieService } from '../../movie.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { of } from 'rxjs/observable/of';


@Component({
  selector: 'app-edit-movie',
  templateUrl: './edit-movie.component.html',
  styleUrls: ['./edit-movie.component.css']
})
export class MovieEditComponent implements OnInit {

  ed: FormGroup;
  movie$: Observable<Movie>;

  constructor(private movieService: MovieService,
  private activateRouter: ActivatedRoute,
    public router: Router)
  {
 
  }

  ngOnInit() {
    const id = this.activateRouter.snapshot.paramMap.get('id');
    this.getMovie(id);
  }

  getMovie(id) {
      this.movieService.getMovie(id).subscribe(res => {
      console.log(res);
      this.ed = new FormGroup({
        'id': new FormControl(res.id, Validators.required),
        'name': new FormControl(res.name, Validators.required),
        'description': new FormControl(res.description, Validators.required),
        'releaseDate': new FormControl(res.releaseDate, Validators.required),
      });
      this.movie$ = of(res);
    });
   
    
  }
  
  save(): void {
    this.movieService.updateMovie(this.ed.getRawValue());
    this.router.navigate['/home'];
  }
}
