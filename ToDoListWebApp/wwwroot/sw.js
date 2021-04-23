var CACHE_NAME = 'my-site-chache';
var urlsToCache = [
    '/',
    '/css/site.css',
    '/js/site.js'
];

self.addEventListener('install', function (event) {
    // Perform install steps
    console.info('Service Worker Installed ....');

    event.waitUntil(
        caches.open(CACHE_NAME)
            .then(function (cache) {
                console.log('Opened cache');
                return cache.addAll(urlsToCache);
            })
    );
    console.info("Caching your application");
});

self.addEventListener('fetch', function (event) {
    event.respondWith(
        caches.match(event.request)
            .then(function (response) {
                // Cache hit - return response
                if (response) {
                    return response;
                }
                return fetch(event.request);
            }
            )
    );
});