PGDMP               	        |         
   TaniAttire    16.2    16.2 M    J           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            K           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            L           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            M           1262    18928 
   TaniAttire    DATABASE     �   CREATE DATABASE "TaniAttire" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'English_Indonesia.1252';
    DROP DATABASE "TaniAttire";
                postgres    false            �            1259    18929    detail_produk    TABLE     �   CREATE TABLE public.detail_produk (
    id_detail_produk integer NOT NULL,
    id_produk integer NOT NULL,
    id_ukuran integer NOT NULL
);
 !   DROP TABLE public.detail_produk;
       public         heap    postgres    false            �            1259    18932    detail_stok    TABLE       CREATE TABLE public.detail_stok (
    id_detail_stok integer NOT NULL,
    id_detail_produk integer NOT NULL,
    stok_sewa integer DEFAULT 0 NOT NULL,
    stok_jual integer DEFAULT 0 NOT NULL,
    harga_sewa numeric(10,2) NOT NULL,
    harga_jual numeric(10,2) NOT NULL
);
    DROP TABLE public.detail_stok;
       public         heap    postgres    false            �            1259    18937    detail_transaksi    TABLE       CREATE TABLE public.detail_transaksi (
    id_detail_transaksi integer NOT NULL,
    id_detail_stok integer NOT NULL,
    id_transaksijual integer,
    id_transaksi_sewa integer,
    jumlah integer NOT NULL,
    CONSTRAINT detailtransaksi_jumlah_check CHECK ((jumlah > 0))
);
 $   DROP TABLE public.detail_transaksi;
       public         heap    postgres    false            �            1259    18941 !   detailproduk_id_detail_produk_seq    SEQUENCE     �   CREATE SEQUENCE public.detailproduk_id_detail_produk_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 8   DROP SEQUENCE public.detailproduk_id_detail_produk_seq;
       public          postgres    false    215            N           0    0 !   detailproduk_id_detail_produk_seq    SEQUENCE OWNED BY     h   ALTER SEQUENCE public.detailproduk_id_detail_produk_seq OWNED BY public.detail_produk.id_detail_produk;
          public          postgres    false    218            �            1259    18942    detailstok_id_detail_stok_seq    SEQUENCE     �   CREATE SEQUENCE public.detailstok_id_detail_stok_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 4   DROP SEQUENCE public.detailstok_id_detail_stok_seq;
       public          postgres    false    216            O           0    0    detailstok_id_detail_stok_seq    SEQUENCE OWNED BY     `   ALTER SEQUENCE public.detailstok_id_detail_stok_seq OWNED BY public.detail_stok.id_detail_stok;
          public          postgres    false    219            �            1259    18943 '   detailtransaksi_id_detail_transaksi_seq    SEQUENCE     �   CREATE SEQUENCE public.detailtransaksi_id_detail_transaksi_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 >   DROP SEQUENCE public.detailtransaksi_id_detail_transaksi_seq;
       public          postgres    false    217            P           0    0 '   detailtransaksi_id_detail_transaksi_seq    SEQUENCE OWNED BY     t   ALTER SEQUENCE public.detailtransaksi_id_detail_transaksi_seq OWNED BY public.detail_transaksi.id_detail_transaksi;
          public          postgres    false    220            �            1259    18944 	   pelanggan    TABLE     �   CREATE TABLE public.pelanggan (
    id_pelanggan integer NOT NULL,
    nama_pelanggan character varying(100) NOT NULL,
    no_telpon character varying(15),
    alamat text
);
    DROP TABLE public.pelanggan;
       public         heap    postgres    false            �            1259    18949    pelanggan_id_pelanggan_seq    SEQUENCE     �   CREATE SEQUENCE public.pelanggan_id_pelanggan_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 1   DROP SEQUENCE public.pelanggan_id_pelanggan_seq;
       public          postgres    false    221            Q           0    0    pelanggan_id_pelanggan_seq    SEQUENCE OWNED BY     Y   ALTER SEQUENCE public.pelanggan_id_pelanggan_seq OWNED BY public.pelanggan.id_pelanggan;
          public          postgres    false    222            �            1259    18950    produk    TABLE     �   CREATE TABLE public.produk (
    id_produk integer NOT NULL,
    nama_produk character varying(100) NOT NULL,
    status boolean DEFAULT true NOT NULL,
    foto_produk character varying(255),
    denda_perhari numeric(10,2) DEFAULT 0 NOT NULL
);
    DROP TABLE public.produk;
       public         heap    postgres    false            �            1259    18955    produk_id_produk_seq    SEQUENCE     �   CREATE SEQUENCE public.produk_id_produk_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 +   DROP SEQUENCE public.produk_id_produk_seq;
       public          postgres    false    223            R           0    0    produk_id_produk_seq    SEQUENCE OWNED BY     M   ALTER SEQUENCE public.produk_id_produk_seq OWNED BY public.produk.id_produk;
          public          postgres    false    224            �            1259    18956    transaksijual    TABLE     �   CREATE TABLE public.transaksijual (
    id_transaksijual integer NOT NULL,
    id_users integer NOT NULL,
    id_pelanggan integer NOT NULL,
    tanggal_transaksi timestamp without time zone DEFAULT now() NOT NULL
);
 !   DROP TABLE public.transaksijual;
       public         heap    postgres    false            �            1259    18960 "   transaksijual_id_transaksijual_seq    SEQUENCE     �   CREATE SEQUENCE public.transaksijual_id_transaksijual_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 9   DROP SEQUENCE public.transaksijual_id_transaksijual_seq;
       public          postgres    false    225            S           0    0 "   transaksijual_id_transaksijual_seq    SEQUENCE OWNED BY     i   ALTER SEQUENCE public.transaksijual_id_transaksijual_seq OWNED BY public.transaksijual.id_transaksijual;
          public          postgres    false    226            �            1259    18961    transaksisewa    TABLE     �  CREATE TABLE public.transaksisewa (
    id_transaksisewa integer NOT NULL,
    id_users integer NOT NULL,
    id_pelanggan integer NOT NULL,
    tanggal_transaksi timestamp without time zone DEFAULT now() NOT NULL,
    tanggal_kembali timestamp without time zone NOT NULL,
    tanggal_pengembalian timestamp without time zone,
    status_pengembalian boolean DEFAULT false NOT NULL
);
 !   DROP TABLE public.transaksisewa;
       public         heap    postgres    false            �            1259    18967 "   transaksisewa_id_transaksisewa_seq    SEQUENCE     �   CREATE SEQUENCE public.transaksisewa_id_transaksisewa_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 9   DROP SEQUENCE public.transaksisewa_id_transaksisewa_seq;
       public          postgres    false    227            T           0    0 "   transaksisewa_id_transaksisewa_seq    SEQUENCE OWNED BY     i   ALTER SEQUENCE public.transaksisewa_id_transaksisewa_seq OWNED BY public.transaksisewa.id_transaksisewa;
          public          postgres    false    228            �            1259    18968    ukuran    TABLE     �   CREATE TABLE public.ukuran (
    id_ukuran integer NOT NULL,
    kategori character varying(50) NOT NULL,
    nilai_ukuran character varying(50),
    status boolean DEFAULT true NOT NULL
);
    DROP TABLE public.ukuran;
       public         heap    postgres    false            �            1259    18972    ukuran_id_ukuran_seq    SEQUENCE     �   CREATE SEQUENCE public.ukuran_id_ukuran_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 +   DROP SEQUENCE public.ukuran_id_ukuran_seq;
       public          postgres    false    229            U           0    0    ukuran_id_ukuran_seq    SEQUENCE OWNED BY     M   ALTER SEQUENCE public.ukuran_id_ukuran_seq OWNED BY public.ukuran.id_ukuran;
          public          postgres    false    230            �            1259    18973    users    TABLE     1  CREATE TABLE public.users (
    id_users integer NOT NULL,
    username character varying(50) NOT NULL,
    password character varying(255) NOT NULL,
    role character varying(20) NOT NULL,
    nama character varying(100) NOT NULL,
    no_telpon character varying(15),
    status boolean DEFAULT true
);
    DROP TABLE public.users;
       public         heap    postgres    false            �            1259    18976    users_id_users_seq    SEQUENCE     �   CREATE SEQUENCE public.users_id_users_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 )   DROP SEQUENCE public.users_id_users_seq;
       public          postgres    false    231            V           0    0    users_id_users_seq    SEQUENCE OWNED BY     I   ALTER SEQUENCE public.users_id_users_seq OWNED BY public.users.id_users;
          public          postgres    false    232            x           2604    18977    detail_produk id_detail_produk    DEFAULT     �   ALTER TABLE ONLY public.detail_produk ALTER COLUMN id_detail_produk SET DEFAULT nextval('public.detailproduk_id_detail_produk_seq'::regclass);
 M   ALTER TABLE public.detail_produk ALTER COLUMN id_detail_produk DROP DEFAULT;
       public          postgres    false    218    215            y           2604    18978    detail_stok id_detail_stok    DEFAULT     �   ALTER TABLE ONLY public.detail_stok ALTER COLUMN id_detail_stok SET DEFAULT nextval('public.detailstok_id_detail_stok_seq'::regclass);
 I   ALTER TABLE public.detail_stok ALTER COLUMN id_detail_stok DROP DEFAULT;
       public          postgres    false    219    216            |           2604    18979 $   detail_transaksi id_detail_transaksi    DEFAULT     �   ALTER TABLE ONLY public.detail_transaksi ALTER COLUMN id_detail_transaksi SET DEFAULT nextval('public.detailtransaksi_id_detail_transaksi_seq'::regclass);
 S   ALTER TABLE public.detail_transaksi ALTER COLUMN id_detail_transaksi DROP DEFAULT;
       public          postgres    false    220    217            }           2604    18980    pelanggan id_pelanggan    DEFAULT     �   ALTER TABLE ONLY public.pelanggan ALTER COLUMN id_pelanggan SET DEFAULT nextval('public.pelanggan_id_pelanggan_seq'::regclass);
 E   ALTER TABLE public.pelanggan ALTER COLUMN id_pelanggan DROP DEFAULT;
       public          postgres    false    222    221            ~           2604    18981    produk id_produk    DEFAULT     t   ALTER TABLE ONLY public.produk ALTER COLUMN id_produk SET DEFAULT nextval('public.produk_id_produk_seq'::regclass);
 ?   ALTER TABLE public.produk ALTER COLUMN id_produk DROP DEFAULT;
       public          postgres    false    224    223            �           2604    18982    transaksijual id_transaksijual    DEFAULT     �   ALTER TABLE ONLY public.transaksijual ALTER COLUMN id_transaksijual SET DEFAULT nextval('public.transaksijual_id_transaksijual_seq'::regclass);
 M   ALTER TABLE public.transaksijual ALTER COLUMN id_transaksijual DROP DEFAULT;
       public          postgres    false    226    225            �           2604    18983    transaksisewa id_transaksisewa    DEFAULT     �   ALTER TABLE ONLY public.transaksisewa ALTER COLUMN id_transaksisewa SET DEFAULT nextval('public.transaksisewa_id_transaksisewa_seq'::regclass);
 M   ALTER TABLE public.transaksisewa ALTER COLUMN id_transaksisewa DROP DEFAULT;
       public          postgres    false    228    227            �           2604    18984    ukuran id_ukuran    DEFAULT     t   ALTER TABLE ONLY public.ukuran ALTER COLUMN id_ukuran SET DEFAULT nextval('public.ukuran_id_ukuran_seq'::regclass);
 ?   ALTER TABLE public.ukuran ALTER COLUMN id_ukuran DROP DEFAULT;
       public          postgres    false    230    229            �           2604    18985    users id_users    DEFAULT     p   ALTER TABLE ONLY public.users ALTER COLUMN id_users SET DEFAULT nextval('public.users_id_users_seq'::regclass);
 =   ALTER TABLE public.users ALTER COLUMN id_users DROP DEFAULT;
       public          postgres    false    232    231            6          0    18929    detail_produk 
   TABLE DATA           O   COPY public.detail_produk (id_detail_produk, id_produk, id_ukuran) FROM stdin;
    public          postgres    false    215   �b       7          0    18932    detail_stok 
   TABLE DATA           u   COPY public.detail_stok (id_detail_stok, id_detail_produk, stok_sewa, stok_jual, harga_sewa, harga_jual) FROM stdin;
    public          postgres    false    216   /c       8          0    18937    detail_transaksi 
   TABLE DATA           |   COPY public.detail_transaksi (id_detail_transaksi, id_detail_stok, id_transaksijual, id_transaksi_sewa, jumlah) FROM stdin;
    public          postgres    false    217   �c       <          0    18944 	   pelanggan 
   TABLE DATA           T   COPY public.pelanggan (id_pelanggan, nama_pelanggan, no_telpon, alamat) FROM stdin;
    public          postgres    false    221   �c       >          0    18950    produk 
   TABLE DATA           \   COPY public.produk (id_produk, nama_produk, status, foto_produk, denda_perhari) FROM stdin;
    public          postgres    false    223   Bd       @          0    18956    transaksijual 
   TABLE DATA           d   COPY public.transaksijual (id_transaksijual, id_users, id_pelanggan, tanggal_transaksi) FROM stdin;
    public          postgres    false    225   6e       B          0    18961    transaksisewa 
   TABLE DATA           �   COPY public.transaksisewa (id_transaksisewa, id_users, id_pelanggan, tanggal_transaksi, tanggal_kembali, tanggal_pengembalian, status_pengembalian) FROM stdin;
    public          postgres    false    227   re       D          0    18968    ukuran 
   TABLE DATA           K   COPY public.ukuran (id_ukuran, kategori, nilai_ukuran, status) FROM stdin;
    public          postgres    false    229   �e       F          0    18973    users 
   TABLE DATA           \   COPY public.users (id_users, username, password, role, nama, no_telpon, status) FROM stdin;
    public          postgres    false    231   Mf       W           0    0 !   detailproduk_id_detail_produk_seq    SEQUENCE SET     O   SELECT pg_catalog.setval('public.detailproduk_id_detail_produk_seq', 4, true);
          public          postgres    false    218            X           0    0    detailstok_id_detail_stok_seq    SEQUENCE SET     K   SELECT pg_catalog.setval('public.detailstok_id_detail_stok_seq', 4, true);
          public          postgres    false    219            Y           0    0 '   detailtransaksi_id_detail_transaksi_seq    SEQUENCE SET     U   SELECT pg_catalog.setval('public.detailtransaksi_id_detail_transaksi_seq', 2, true);
          public          postgres    false    220            Z           0    0    pelanggan_id_pelanggan_seq    SEQUENCE SET     H   SELECT pg_catalog.setval('public.pelanggan_id_pelanggan_seq', 4, true);
          public          postgres    false    222            [           0    0    produk_id_produk_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public.produk_id_produk_seq', 4, true);
          public          postgres    false    224            \           0    0 "   transaksijual_id_transaksijual_seq    SEQUENCE SET     P   SELECT pg_catalog.setval('public.transaksijual_id_transaksijual_seq', 1, true);
          public          postgres    false    226            ]           0    0 "   transaksisewa_id_transaksisewa_seq    SEQUENCE SET     P   SELECT pg_catalog.setval('public.transaksisewa_id_transaksisewa_seq', 1, true);
          public          postgres    false    228            ^           0    0    ukuran_id_ukuran_seq    SEQUENCE SET     C   SELECT pg_catalog.setval('public.ukuran_id_ukuran_seq', 17, true);
          public          postgres    false    230            _           0    0    users_id_users_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public.users_id_users_seq', 8, true);
          public          postgres    false    232            �           2606    18987    detail_produk detailproduk_pkey 
   CONSTRAINT     k   ALTER TABLE ONLY public.detail_produk
    ADD CONSTRAINT detailproduk_pkey PRIMARY KEY (id_detail_produk);
 I   ALTER TABLE ONLY public.detail_produk DROP CONSTRAINT detailproduk_pkey;
       public            postgres    false    215            �           2606    18989    detail_stok detailstok_pkey 
   CONSTRAINT     e   ALTER TABLE ONLY public.detail_stok
    ADD CONSTRAINT detailstok_pkey PRIMARY KEY (id_detail_stok);
 E   ALTER TABLE ONLY public.detail_stok DROP CONSTRAINT detailstok_pkey;
       public            postgres    false    216            �           2606    18991 %   detail_transaksi detailtransaksi_pkey 
   CONSTRAINT     t   ALTER TABLE ONLY public.detail_transaksi
    ADD CONSTRAINT detailtransaksi_pkey PRIMARY KEY (id_detail_transaksi);
 O   ALTER TABLE ONLY public.detail_transaksi DROP CONSTRAINT detailtransaksi_pkey;
       public            postgres    false    217            �           2606    18993    pelanggan pelanggan_pkey 
   CONSTRAINT     `   ALTER TABLE ONLY public.pelanggan
    ADD CONSTRAINT pelanggan_pkey PRIMARY KEY (id_pelanggan);
 B   ALTER TABLE ONLY public.pelanggan DROP CONSTRAINT pelanggan_pkey;
       public            postgres    false    221            �           2606    18995    produk produk_pkey 
   CONSTRAINT     W   ALTER TABLE ONLY public.produk
    ADD CONSTRAINT produk_pkey PRIMARY KEY (id_produk);
 <   ALTER TABLE ONLY public.produk DROP CONSTRAINT produk_pkey;
       public            postgres    false    223            �           2606    18997     transaksijual transaksijual_pkey 
   CONSTRAINT     l   ALTER TABLE ONLY public.transaksijual
    ADD CONSTRAINT transaksijual_pkey PRIMARY KEY (id_transaksijual);
 J   ALTER TABLE ONLY public.transaksijual DROP CONSTRAINT transaksijual_pkey;
       public            postgres    false    225            �           2606    18999     transaksisewa transaksisewa_pkey 
   CONSTRAINT     l   ALTER TABLE ONLY public.transaksisewa
    ADD CONSTRAINT transaksisewa_pkey PRIMARY KEY (id_transaksisewa);
 J   ALTER TABLE ONLY public.transaksisewa DROP CONSTRAINT transaksisewa_pkey;
       public            postgres    false    227            �           2606    19001    ukuran ukuran_pkey 
   CONSTRAINT     W   ALTER TABLE ONLY public.ukuran
    ADD CONSTRAINT ukuran_pkey PRIMARY KEY (id_ukuran);
 <   ALTER TABLE ONLY public.ukuran DROP CONSTRAINT ukuran_pkey;
       public            postgres    false    229            �           2606    19003    users users_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (id_users);
 :   ALTER TABLE ONLY public.users DROP CONSTRAINT users_pkey;
       public            postgres    false    231            �           2606    19004 )   detail_produk detailproduk_id_produk_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.detail_produk
    ADD CONSTRAINT detailproduk_id_produk_fkey FOREIGN KEY (id_produk) REFERENCES public.produk(id_produk) ON DELETE CASCADE;
 S   ALTER TABLE ONLY public.detail_produk DROP CONSTRAINT detailproduk_id_produk_fkey;
       public          postgres    false    223    4756    215            �           2606    19009 )   detail_produk detailproduk_id_ukuran_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.detail_produk
    ADD CONSTRAINT detailproduk_id_ukuran_fkey FOREIGN KEY (id_ukuran) REFERENCES public.ukuran(id_ukuran) ON DELETE CASCADE;
 S   ALTER TABLE ONLY public.detail_produk DROP CONSTRAINT detailproduk_id_ukuran_fkey;
       public          postgres    false    229    4762    215            �           2606    19014 ,   detail_stok detailstok_id_detail_produk_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.detail_stok
    ADD CONSTRAINT detailstok_id_detail_produk_fkey FOREIGN KEY (id_detail_produk) REFERENCES public.detail_produk(id_detail_produk) ON DELETE CASCADE;
 V   ALTER TABLE ONLY public.detail_stok DROP CONSTRAINT detailstok_id_detail_produk_fkey;
       public          postgres    false    4748    215    216            �           2606    19019 4   detail_transaksi detailtransaksi_id_detail_stok_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.detail_transaksi
    ADD CONSTRAINT detailtransaksi_id_detail_stok_fkey FOREIGN KEY (id_detail_stok) REFERENCES public.detail_stok(id_detail_stok) ON DELETE CASCADE;
 ^   ALTER TABLE ONLY public.detail_transaksi DROP CONSTRAINT detailtransaksi_id_detail_stok_fkey;
       public          postgres    false    217    216    4750            �           2606    19024 7   detail_transaksi detailtransaksi_id_transaksi_sewa_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.detail_transaksi
    ADD CONSTRAINT detailtransaksi_id_transaksi_sewa_fkey FOREIGN KEY (id_transaksi_sewa) REFERENCES public.transaksisewa(id_transaksisewa) ON DELETE CASCADE;
 a   ALTER TABLE ONLY public.detail_transaksi DROP CONSTRAINT detailtransaksi_id_transaksi_sewa_fkey;
       public          postgres    false    217    227    4760            �           2606    19029 6   detail_transaksi detailtransaksi_id_transaksijual_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.detail_transaksi
    ADD CONSTRAINT detailtransaksi_id_transaksijual_fkey FOREIGN KEY (id_transaksijual) REFERENCES public.transaksijual(id_transaksijual) ON DELETE CASCADE;
 `   ALTER TABLE ONLY public.detail_transaksi DROP CONSTRAINT detailtransaksi_id_transaksijual_fkey;
       public          postgres    false    225    4758    217            �           2606    19034 -   transaksijual transaksijual_id_pelanggan_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.transaksijual
    ADD CONSTRAINT transaksijual_id_pelanggan_fkey FOREIGN KEY (id_pelanggan) REFERENCES public.pelanggan(id_pelanggan) ON DELETE CASCADE;
 W   ALTER TABLE ONLY public.transaksijual DROP CONSTRAINT transaksijual_id_pelanggan_fkey;
       public          postgres    false    225    221    4754            �           2606    19039 )   transaksijual transaksijual_id_users_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.transaksijual
    ADD CONSTRAINT transaksijual_id_users_fkey FOREIGN KEY (id_users) REFERENCES public.users(id_users) ON DELETE SET NULL;
 S   ALTER TABLE ONLY public.transaksijual DROP CONSTRAINT transaksijual_id_users_fkey;
       public          postgres    false    4764    231    225            �           2606    19044 -   transaksisewa transaksisewa_id_pelanggan_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.transaksisewa
    ADD CONSTRAINT transaksisewa_id_pelanggan_fkey FOREIGN KEY (id_pelanggan) REFERENCES public.pelanggan(id_pelanggan) ON DELETE CASCADE;
 W   ALTER TABLE ONLY public.transaksisewa DROP CONSTRAINT transaksisewa_id_pelanggan_fkey;
       public          postgres    false    221    227    4754            �           2606    19049 )   transaksisewa transaksisewa_id_users_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.transaksisewa
    ADD CONSTRAINT transaksisewa_id_users_fkey FOREIGN KEY (id_users) REFERENCES public.users(id_users) ON DELETE SET NULL;
 S   ALTER TABLE ONLY public.transaksisewa DROP CONSTRAINT transaksisewa_id_users_fkey;
       public          postgres    false    4764    227    231            6   #   x�3�4�44�2�4�44��A<N#���� I�F      7   A   x�5�A 1��F���c��wT�DF6�e�N:_��D��]N^�cŠ@�Zh��»H>��      8      x�3�4�?N#.#������ 8��      <   �   x�M̽
� @���>@��k�@K��]nH�(H�������LG@��Ricgg9�j�J�9�B$d�b:�wx��Zz���y��:X�|c��¨�]��@�ai{ڻ�����g�#��Lt��10B���+E      >   �   x���=N�@��>�/0����AA�HѮ��,��(v���B$
���M�>��U�c^��\R�V���x�Lg@e�yK0�ޡqtR���S�e��k#P( �9���q�Ѹ�5U�˗f�%���V���|3�����o�\��b8'�W�"\r����2���Ǣ�ʊ+��G8����!���W�n�����)̧yc�x"c,x�G���d��U��w��g�u]�{      @   ,   x�3�4�4�4202�54�5�P00�"#=#cs�=... }�v      B   <   x�3�4�4�4202�54�5�P04�20�25�3�01�D��T0 J�\��!V����� ?�>      D      x�M�=�0���ǈ�hR��
B�.7(��"��?߻��އ����o*\�v0�X!�3�5H<�����=\i�'-k-膞e�Z��2��V����,�-�c-&�N'f�W~�aw����ט�21oD��L>/      F   �   x���M� ���)zS�{�tC��`M���N�&n�L�}�=�`w܇^=&�����c0�ͽ"�x���!~_��-!Db�ԛ,��5��i@Rea�#��֩+�u9�s�ӴZQR�b�bi�pu���tw�C�r��V;B�/��s�p�D�     