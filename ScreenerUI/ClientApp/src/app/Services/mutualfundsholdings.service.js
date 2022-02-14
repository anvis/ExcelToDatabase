"use strict";
////import { Injectable, Inject } from '@angular/core';
////import { Http, Response } from '@angular/http';
////import { Observable } from 'rxjs/Observable';
//import { Router } from '@angular/router';
////import 'rxjs/add/operator/map';
////import 'rxjs/add/operator/catch';
////import 'rxjs/add/observable/throw';
Object.defineProperty(exports, "__esModule", { value: true });
var operators_1 = require("rxjs/operators");
({ providedIn: 'root' });
var mutualfundsholdingsService = /** @class */ (function () {
    function mutualfundsholdingsService(http, sanitizer) {
        this.http = http;
        this.sanitizer = sanitizer;
        this.url = 'https://public-api.wordpress.com/rest/v1.1/sites/vocon-it.com/posts';
    }
    mutualfundsholdingsService.prototype.ngOnInit = function () {
        //  throw new Error("Method not implemented.");
    };
    // Rest Items Service: Read all REST Items
    mutualfundsholdingsService.prototype.getAll = function () {
        return this.http
            .get(this.url)
            .pipe(operators_1.map(function (data) { return data; }));
    };
    return mutualfundsholdingsService;
}());
exports.mutualfundsholdingsService = mutualfundsholdingsService;
//# sourceMappingURL=mutualfundsholdings.service.js.map