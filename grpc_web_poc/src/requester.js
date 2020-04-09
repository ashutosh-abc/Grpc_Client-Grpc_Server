import React from 'react';
import * as grpcWeb from 'grpc-web';
import {BookServiceClient} from './_proto/examplecom/library/book_service_pb';
import { GetBookRequest, Book } from './_proto/examplecom/library/book_service_pb';

const bookClient = new BookServiceClient("https:localhost/5001",null,null);
export class BookApp {
   
    getBook = (id) => {
        return new Promise((resolve,reject) => {
            const request = new GetBookRequest();
            request.setIsbn(id);
            bookClient.getBook(request,{},(err, response) => {
                if(!err){
                    resolve(response);
                }
                else {
                    reject(err);
                }
            });      
        })
       }
}




