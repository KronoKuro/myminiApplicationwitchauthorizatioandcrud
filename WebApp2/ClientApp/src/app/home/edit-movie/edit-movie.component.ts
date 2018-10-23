import { Component, OnInit, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { Router, ActivatedRoute } from '@angular/router';
import { Movie } from '../../models/movie.model';
import { MovieService } from '../../movie.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';


@Component({
  selector: 'app-edit-movie',
  templateUrl: './edit-movie.component.html',
  styleUrls: ['./edit-movie.component.css']
})
export class MovieEditComponent implements OnInit {

  ed: FormGroup;
  
  constructor(private movieService: MovieService,
  private activateRouter: ActivatedRoute,
    public router: Router)
  {
 
  }

  ngOnInit() {
    this.getMovie();
  }

  getMovie() {
    const id = this.activateRouter.snapshot.paramMap.get('id');
    this.movieService.getMovie(id).subscribe(res => {
    this.ed = new FormGroup({
        'id': new FormControl(res.id, Validators.required),
        'name': new FormControl(res.name, Validators.required),
        'description': new FormControl(res.description, Validators.required),
        'releaseDate': new FormControl(res.releaseDate, Validators.required),
      });
    });
    
  }
  
  save(): void {
    this.movieService.updateMovie(this.ed.getRawValue());
    this.router.navigate['/home'];
  }
}
