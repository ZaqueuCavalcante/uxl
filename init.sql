DROP TABLE IF EXISTS urls;
DROP TABLE IF EXISTS url_clicks;

CREATE TABLE urls (
    id uuid NOT NULL,
    hash text NOT NULL,
    target text NOT NULL,
    created_at timestamp without time zone NOT NULL,
    CONSTRAINT pk_urls PRIMARY KEY (id)
);

CREATE TABLE url_clicks (
    id uuid NOT NULL,
    hash text NOT NULL,
    created_at timestamp without time zone NOT NULL,
    CONSTRAINT pk_url_clicks PRIMARY KEY (id)
);

CREATE UNIQUE INDEX ix_urls_hash ON urls (hash);
