var express = require ('express');
var app = express ();
var path = require ('path');

var port = 8000;
app.use (express.static ('dist'));

app.get ('/', (req, res) => {
    res.sendFile (path.join (__dirname, 'dist', 'coach.html'));
});

app.get ('/reception', (req, res) => {
    res.sendFile (path.join (__dirname, 'dist', 'reception.html'));
});

app.get ('/manager', (req, res) => {
    res.sendFile (path.join (__dirname, 'dist', 'manager.html'));
});

app.get ('/admin', (req, res) => {
    res.sendFile (path.join (__dirname, 'dist', 'admin.html'));
});

app.listen (port, () => {
    console.log ('Server is running at http://localhost:' + port);
});