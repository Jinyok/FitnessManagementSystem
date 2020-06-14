var express = require ('express');
var app = express ();
var path = require ('path');

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

app.listen (8000);