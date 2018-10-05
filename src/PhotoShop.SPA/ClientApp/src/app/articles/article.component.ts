import { Component } from "@angular/core";
import { Subject } from "rxjs";

@Component({
  templateUrl: "./article.component.html",
  styleUrls: ["./article.component.css"],
  selector: "app-article"
})
export class ArticleComponent { 

  public onDestroy: Subject<void> = new Subject<void>();

  ngOnDestroy() {
    this.onDestroy.next();	
  }
}
