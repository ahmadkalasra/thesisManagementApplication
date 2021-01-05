TO START URL REWRITING ON IIS

1. Use ISAPIRewrite

If you have IsapiRewrite installed, use the following code to start URL rewriting for the web site that will host Short URL.

RewriteRule / /default\.aspx [I,L]
RewriteRule /((\w|/|\s|:|\?|\&|=|%|-|_)*) /redirection\.aspx?page=$1 [I,L]

2. IIS CUSTOM ERRORS

If you do not have IsapiRewrite installed, open up IIS, right-click your website and choose properties, choose the Custom Errors tab, and edit the 404 entry so that it goes to the URL /Redirection.aspx