import http from "@/http-common";

/* eslint-disable */
class FoodeadorDataService {
  

  create(data: any): Promise<any> {
    return http.post("/usuario/crear", data);
  }

  createSupermercado(data: any): Promise<any> {
    return http.post("/supermercado/crear", data);
  }

  guardarPrecio(data: any): Promise<any> {
    console.log(data)
    return http.post("/precio/crear", data);
  }

  createProducto(data: any): Promise<any> {
    return http.post("/producto/crear", data);
  }

  createPrecio(data: any): Promise<any> {
    console.log("precio que envio")
    console.log(data)
    return http.post("/precio/crear", data);
  }

  identificar(data: any): Promise<any> {
    console.log("envio")
    console.log(data)
   
    
    return http.post("/usuario/identificar",data);
  }

  getAll(): Promise<any> {
    return http.get("/");
  }

  getProductosUsuario(id:number): Promise<any> {
    return http.get("/producto/usuario/"+id);
  }

  

  detalleProducto(id:number): Promise<any> {
    return http.get("/producto/"+id);
  }

  detalleSupermercado(id:number): Promise<any> {
    return http.get("/supermercado/"+id);
  }

  getSupermercadosUsuario(id:number): Promise<any> {
    console.log("mando el :"+id)
    return http.get("/supermercado/usuario/"+id);
  }


  getPreciosUsuario(id:number): Promise<any> {
    return http.get("/precio/usuario/"+id);
  }

  getPreciosProducto(id:number): Promise<any> {
    return http.get("/precio/producto/"+id);
  }

  getPreciosSupermercado(id:number): Promise<any> {
    return http.get("/precio/supermercado/"+id);
  }

  buscarSupermercado(nombre:string): Promise<any> {
    return http.get("/supermercado?nombre="+nombre);
  }

  buscarSupermercadosTodos(): Promise<any> {
    return http.get("/supermercado/todos");
  }

  buscarProducto(nombre:string): Promise<any> {
    return http.get("/producto?nombre="+nombre);
  }

  buscarProductosTodos(): Promise<any> {
    return http.get("/producto/todos");
  }

  deleteSupermercado(id: any): Promise<any> {
    return http.delete(`/supermercado/${id}`);
  }
  deleteProducto(id: any): Promise<any> {
    return http.delete(`/producto/${id}`);
  }

  updateSupermercado( data: any): Promise<any> {
    return http.put(`/supermercado`, data);
  }

  updateProducto( data: any): Promise<any> {
    return http.put(`/producto`, data);
  }

 
}

export default new FoodeadorDataService();
