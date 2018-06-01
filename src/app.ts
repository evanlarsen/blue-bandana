import { RouterConfiguration, Router } from 'aurelia-router';
import { PLATFORM } from 'aurelia-pal';

export class App {
  router: Router;

  configureRouter(config: RouterConfiguration, router: Router){
    console.log('configure router');
    this.router = router;
    config.title = 'Blue Bandana';
    // config.options.pushState = true;
    // config.options.root = '/';
    config.map([
      { route: ['', 'welcome'], name: 'welcome', moduleId: PLATFORM.moduleName('ui/welcome'), nav: true, title: 'Welcome' }
    ]);
    config.mapUnknownRoutes(PLATFORM.moduleName('ui/not-found'));
  }
}
