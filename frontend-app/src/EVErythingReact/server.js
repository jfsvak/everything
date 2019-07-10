var express = require('express');
var path = require('path');

const app = express();

app.get('/helloworld', function(req, res) {
    res.send('hello world');
});

app.use(express.static(path.join(__dirname, "dist")));

app.listen(3000, () => console.log('Listens on port 3000'));