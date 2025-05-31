
package ec.edu.monster.controller;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlElementDecl;
import javax.xml.bind.annotation.XmlRegistry;
import javax.xml.namespace.QName;


/**
 * This object contains factory methods for each 
 * Java content interface and Java element interface 
 * generated in the ec.edu.monster.controller package. 
 * <p>An ObjectFactory allows you to programatically 
 * construct new instances of the Java representation 
 * for XML content. The Java representation of XML 
 * content can consist of schema derived interfaces 
 * and classes representing the binding of schema 
 * type definitions, element declarations and model 
 * groups.  Factory methods for each of these are 
 * provided in this class.
 * 
 */
@XmlRegistry
public class ObjectFactory {

    private final static QName _Boleto_QNAME = new QName("http://controller.monster.edu.ec/", "boleto");
    private final static QName _BuscarVuelos_QNAME = new QName("http://controller.monster.edu.ec/", "buscarVuelos");
    private final static QName _BuscarVuelosResponse_QNAME = new QName("http://controller.monster.edu.ec/", "buscarVuelosResponse");
    private final static QName _ComprarBoletos_QNAME = new QName("http://controller.monster.edu.ec/", "comprarBoletos");
    private final static QName _ComprarBoletosResponse_QNAME = new QName("http://controller.monster.edu.ec/", "comprarBoletosResponse");
    private final static QName _Login_QNAME = new QName("http://controller.monster.edu.ec/", "login");
    private final static QName _LoginResponse_QNAME = new QName("http://controller.monster.edu.ec/", "loginResponse");
    private final static QName _MostrarBoletosUsuario_QNAME = new QName("http://controller.monster.edu.ec/", "mostrarBoletosUsuario");
    private final static QName _MostrarBoletosUsuarioResponse_QNAME = new QName("http://controller.monster.edu.ec/", "mostrarBoletosUsuarioResponse");
    private final static QName _MostrarTodosVuelos_QNAME = new QName("http://controller.monster.edu.ec/", "mostrarTodosVuelos");
    private final static QName _MostrarTodosVuelosResponse_QNAME = new QName("http://controller.monster.edu.ec/", "mostrarTodosVuelosResponse");
    private final static QName _ObtenerIdUsuarioPorEmail_QNAME = new QName("http://controller.monster.edu.ec/", "obtenerIdUsuarioPorEmail");
    private final static QName _ObtenerIdUsuarioPorEmailResponse_QNAME = new QName("http://controller.monster.edu.ec/", "obtenerIdUsuarioPorEmailResponse");
    private final static QName _RegistrarUsuario_QNAME = new QName("http://controller.monster.edu.ec/", "registrarUsuario");
    private final static QName _RegistrarUsuarioResponse_QNAME = new QName("http://controller.monster.edu.ec/", "registrarUsuarioResponse");
    private final static QName _Vuelo_QNAME = new QName("http://controller.monster.edu.ec/", "vuelo");

    /**
     * Create a new ObjectFactory that can be used to create new instances of schema derived classes for package: ec.edu.monster.controller
     * 
     */
    public ObjectFactory() {
    }

    /**
     * Create an instance of {@link Boleto }
     * 
     */
    public Boleto createBoleto() {
        return new Boleto();
    }

    /**
     * Create an instance of {@link BuscarVuelos }
     * 
     */
    public BuscarVuelos createBuscarVuelos() {
        return new BuscarVuelos();
    }

    /**
     * Create an instance of {@link BuscarVuelosResponse }
     * 
     */
    public BuscarVuelosResponse createBuscarVuelosResponse() {
        return new BuscarVuelosResponse();
    }

    /**
     * Create an instance of {@link ComprarBoletos }
     * 
     */
    public ComprarBoletos createComprarBoletos() {
        return new ComprarBoletos();
    }

    /**
     * Create an instance of {@link ComprarBoletosResponse }
     * 
     */
    public ComprarBoletosResponse createComprarBoletosResponse() {
        return new ComprarBoletosResponse();
    }

    /**
     * Create an instance of {@link Login }
     * 
     */
    public Login createLogin() {
        return new Login();
    }

    /**
     * Create an instance of {@link LoginResponse }
     * 
     */
    public LoginResponse createLoginResponse() {
        return new LoginResponse();
    }

    /**
     * Create an instance of {@link MostrarBoletosUsuario }
     * 
     */
    public MostrarBoletosUsuario createMostrarBoletosUsuario() {
        return new MostrarBoletosUsuario();
    }

    /**
     * Create an instance of {@link MostrarBoletosUsuarioResponse }
     * 
     */
    public MostrarBoletosUsuarioResponse createMostrarBoletosUsuarioResponse() {
        return new MostrarBoletosUsuarioResponse();
    }

    /**
     * Create an instance of {@link MostrarTodosVuelos }
     * 
     */
    public MostrarTodosVuelos createMostrarTodosVuelos() {
        return new MostrarTodosVuelos();
    }

    /**
     * Create an instance of {@link MostrarTodosVuelosResponse }
     * 
     */
    public MostrarTodosVuelosResponse createMostrarTodosVuelosResponse() {
        return new MostrarTodosVuelosResponse();
    }

    /**
     * Create an instance of {@link ObtenerIdUsuarioPorEmail }
     * 
     */
    public ObtenerIdUsuarioPorEmail createObtenerIdUsuarioPorEmail() {
        return new ObtenerIdUsuarioPorEmail();
    }

    /**
     * Create an instance of {@link ObtenerIdUsuarioPorEmailResponse }
     * 
     */
    public ObtenerIdUsuarioPorEmailResponse createObtenerIdUsuarioPorEmailResponse() {
        return new ObtenerIdUsuarioPorEmailResponse();
    }

    /**
     * Create an instance of {@link RegistrarUsuario }
     * 
     */
    public RegistrarUsuario createRegistrarUsuario() {
        return new RegistrarUsuario();
    }

    /**
     * Create an instance of {@link RegistrarUsuarioResponse }
     * 
     */
    public RegistrarUsuarioResponse createRegistrarUsuarioResponse() {
        return new RegistrarUsuarioResponse();
    }

    /**
     * Create an instance of {@link Vuelo }
     * 
     */
    public Vuelo createVuelo() {
        return new Vuelo();
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link Boleto }{@code >}
     * 
     * @param value
     *     Java instance representing xml element's value.
     * @return
     *     the new instance of {@link JAXBElement }{@code <}{@link Boleto }{@code >}
     */
    @XmlElementDecl(namespace = "http://controller.monster.edu.ec/", name = "boleto")
    public JAXBElement<Boleto> createBoleto(Boleto value) {
        return new JAXBElement<Boleto>(_Boleto_QNAME, Boleto.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link BuscarVuelos }{@code >}
     * 
     * @param value
     *     Java instance representing xml element's value.
     * @return
     *     the new instance of {@link JAXBElement }{@code <}{@link BuscarVuelos }{@code >}
     */
    @XmlElementDecl(namespace = "http://controller.monster.edu.ec/", name = "buscarVuelos")
    public JAXBElement<BuscarVuelos> createBuscarVuelos(BuscarVuelos value) {
        return new JAXBElement<BuscarVuelos>(_BuscarVuelos_QNAME, BuscarVuelos.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link BuscarVuelosResponse }{@code >}
     * 
     * @param value
     *     Java instance representing xml element's value.
     * @return
     *     the new instance of {@link JAXBElement }{@code <}{@link BuscarVuelosResponse }{@code >}
     */
    @XmlElementDecl(namespace = "http://controller.monster.edu.ec/", name = "buscarVuelosResponse")
    public JAXBElement<BuscarVuelosResponse> createBuscarVuelosResponse(BuscarVuelosResponse value) {
        return new JAXBElement<BuscarVuelosResponse>(_BuscarVuelosResponse_QNAME, BuscarVuelosResponse.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link ComprarBoletos }{@code >}
     * 
     * @param value
     *     Java instance representing xml element's value.
     * @return
     *     the new instance of {@link JAXBElement }{@code <}{@link ComprarBoletos }{@code >}
     */
    @XmlElementDecl(namespace = "http://controller.monster.edu.ec/", name = "comprarBoletos")
    public JAXBElement<ComprarBoletos> createComprarBoletos(ComprarBoletos value) {
        return new JAXBElement<ComprarBoletos>(_ComprarBoletos_QNAME, ComprarBoletos.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link ComprarBoletosResponse }{@code >}
     * 
     * @param value
     *     Java instance representing xml element's value.
     * @return
     *     the new instance of {@link JAXBElement }{@code <}{@link ComprarBoletosResponse }{@code >}
     */
    @XmlElementDecl(namespace = "http://controller.monster.edu.ec/", name = "comprarBoletosResponse")
    public JAXBElement<ComprarBoletosResponse> createComprarBoletosResponse(ComprarBoletosResponse value) {
        return new JAXBElement<ComprarBoletosResponse>(_ComprarBoletosResponse_QNAME, ComprarBoletosResponse.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link Login }{@code >}
     * 
     * @param value
     *     Java instance representing xml element's value.
     * @return
     *     the new instance of {@link JAXBElement }{@code <}{@link Login }{@code >}
     */
    @XmlElementDecl(namespace = "http://controller.monster.edu.ec/", name = "login")
    public JAXBElement<Login> createLogin(Login value) {
        return new JAXBElement<Login>(_Login_QNAME, Login.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link LoginResponse }{@code >}
     * 
     * @param value
     *     Java instance representing xml element's value.
     * @return
     *     the new instance of {@link JAXBElement }{@code <}{@link LoginResponse }{@code >}
     */
    @XmlElementDecl(namespace = "http://controller.monster.edu.ec/", name = "loginResponse")
    public JAXBElement<LoginResponse> createLoginResponse(LoginResponse value) {
        return new JAXBElement<LoginResponse>(_LoginResponse_QNAME, LoginResponse.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link MostrarBoletosUsuario }{@code >}
     * 
     * @param value
     *     Java instance representing xml element's value.
     * @return
     *     the new instance of {@link JAXBElement }{@code <}{@link MostrarBoletosUsuario }{@code >}
     */
    @XmlElementDecl(namespace = "http://controller.monster.edu.ec/", name = "mostrarBoletosUsuario")
    public JAXBElement<MostrarBoletosUsuario> createMostrarBoletosUsuario(MostrarBoletosUsuario value) {
        return new JAXBElement<MostrarBoletosUsuario>(_MostrarBoletosUsuario_QNAME, MostrarBoletosUsuario.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link MostrarBoletosUsuarioResponse }{@code >}
     * 
     * @param value
     *     Java instance representing xml element's value.
     * @return
     *     the new instance of {@link JAXBElement }{@code <}{@link MostrarBoletosUsuarioResponse }{@code >}
     */
    @XmlElementDecl(namespace = "http://controller.monster.edu.ec/", name = "mostrarBoletosUsuarioResponse")
    public JAXBElement<MostrarBoletosUsuarioResponse> createMostrarBoletosUsuarioResponse(MostrarBoletosUsuarioResponse value) {
        return new JAXBElement<MostrarBoletosUsuarioResponse>(_MostrarBoletosUsuarioResponse_QNAME, MostrarBoletosUsuarioResponse.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link MostrarTodosVuelos }{@code >}
     * 
     * @param value
     *     Java instance representing xml element's value.
     * @return
     *     the new instance of {@link JAXBElement }{@code <}{@link MostrarTodosVuelos }{@code >}
     */
    @XmlElementDecl(namespace = "http://controller.monster.edu.ec/", name = "mostrarTodosVuelos")
    public JAXBElement<MostrarTodosVuelos> createMostrarTodosVuelos(MostrarTodosVuelos value) {
        return new JAXBElement<MostrarTodosVuelos>(_MostrarTodosVuelos_QNAME, MostrarTodosVuelos.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link MostrarTodosVuelosResponse }{@code >}
     * 
     * @param value
     *     Java instance representing xml element's value.
     * @return
     *     the new instance of {@link JAXBElement }{@code <}{@link MostrarTodosVuelosResponse }{@code >}
     */
    @XmlElementDecl(namespace = "http://controller.monster.edu.ec/", name = "mostrarTodosVuelosResponse")
    public JAXBElement<MostrarTodosVuelosResponse> createMostrarTodosVuelosResponse(MostrarTodosVuelosResponse value) {
        return new JAXBElement<MostrarTodosVuelosResponse>(_MostrarTodosVuelosResponse_QNAME, MostrarTodosVuelosResponse.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link ObtenerIdUsuarioPorEmail }{@code >}
     * 
     * @param value
     *     Java instance representing xml element's value.
     * @return
     *     the new instance of {@link JAXBElement }{@code <}{@link ObtenerIdUsuarioPorEmail }{@code >}
     */
    @XmlElementDecl(namespace = "http://controller.monster.edu.ec/", name = "obtenerIdUsuarioPorEmail")
    public JAXBElement<ObtenerIdUsuarioPorEmail> createObtenerIdUsuarioPorEmail(ObtenerIdUsuarioPorEmail value) {
        return new JAXBElement<ObtenerIdUsuarioPorEmail>(_ObtenerIdUsuarioPorEmail_QNAME, ObtenerIdUsuarioPorEmail.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link ObtenerIdUsuarioPorEmailResponse }{@code >}
     * 
     * @param value
     *     Java instance representing xml element's value.
     * @return
     *     the new instance of {@link JAXBElement }{@code <}{@link ObtenerIdUsuarioPorEmailResponse }{@code >}
     */
    @XmlElementDecl(namespace = "http://controller.monster.edu.ec/", name = "obtenerIdUsuarioPorEmailResponse")
    public JAXBElement<ObtenerIdUsuarioPorEmailResponse> createObtenerIdUsuarioPorEmailResponse(ObtenerIdUsuarioPorEmailResponse value) {
        return new JAXBElement<ObtenerIdUsuarioPorEmailResponse>(_ObtenerIdUsuarioPorEmailResponse_QNAME, ObtenerIdUsuarioPorEmailResponse.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link RegistrarUsuario }{@code >}
     * 
     * @param value
     *     Java instance representing xml element's value.
     * @return
     *     the new instance of {@link JAXBElement }{@code <}{@link RegistrarUsuario }{@code >}
     */
    @XmlElementDecl(namespace = "http://controller.monster.edu.ec/", name = "registrarUsuario")
    public JAXBElement<RegistrarUsuario> createRegistrarUsuario(RegistrarUsuario value) {
        return new JAXBElement<RegistrarUsuario>(_RegistrarUsuario_QNAME, RegistrarUsuario.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link RegistrarUsuarioResponse }{@code >}
     * 
     * @param value
     *     Java instance representing xml element's value.
     * @return
     *     the new instance of {@link JAXBElement }{@code <}{@link RegistrarUsuarioResponse }{@code >}
     */
    @XmlElementDecl(namespace = "http://controller.monster.edu.ec/", name = "registrarUsuarioResponse")
    public JAXBElement<RegistrarUsuarioResponse> createRegistrarUsuarioResponse(RegistrarUsuarioResponse value) {
        return new JAXBElement<RegistrarUsuarioResponse>(_RegistrarUsuarioResponse_QNAME, RegistrarUsuarioResponse.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link Vuelo }{@code >}
     * 
     * @param value
     *     Java instance representing xml element's value.
     * @return
     *     the new instance of {@link JAXBElement }{@code <}{@link Vuelo }{@code >}
     */
    @XmlElementDecl(namespace = "http://controller.monster.edu.ec/", name = "vuelo")
    public JAXBElement<Vuelo> createVuelo(Vuelo value) {
        return new JAXBElement<Vuelo>(_Vuelo_QNAME, Vuelo.class, null, value);
    }

}
