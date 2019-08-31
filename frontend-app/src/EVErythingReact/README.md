# React Client for EVErything
## How to run local dev
> npm start


## Generate API's from local service
> gradle 


## Build dev to run in nodejs container
> npm run build-dev


## Deploying/run on k8s
.s2i/bin/assemble is run on build. This will create an image with the code pre-build using
   > npm run build-dev

ENV NPM_RUN=server set in DeploymentConfig to trigger package.json script server, which runs 
> node server.js

and server.js serves the dist folder with 
> app.use(express.static(path.join(__dirname, "dist")));

