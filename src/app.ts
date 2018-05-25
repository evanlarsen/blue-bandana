import { RouterConfiguration, Router } from 'aurelia-router';

export class App {
  router: Router;

  cofigureRouter(config: RouterConfiguration, router: Router){
    this.router = router;
    config.title = 'Blue Bandana';
    config.options.pushState = true;
    config.options.root = '/';
    config.map([
      { route: ['', 'home'], name: 'home', moduleId: 'home/index' }
    ]);
  }
}
